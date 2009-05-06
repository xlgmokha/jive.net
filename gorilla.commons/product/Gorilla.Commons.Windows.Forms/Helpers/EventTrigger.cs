using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Gorilla.Commons.Utility.Extensions;

namespace Gorilla.Commons.Windows.Forms.Helpers
{
    public static class EventTrigger
    {
        const BindingFlags binding_flags =
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance;

        static readonly IDictionary<ExpressionType, Func<Expression, object>> expression_handlers;

        static EventTrigger()
        {
            expression_handlers = new Dictionary<ExpressionType, Func<Expression, object>>();
            expression_handlers[ExpressionType.New] = instantiate_value;
            expression_handlers[ExpressionType.MemberAccess] = get_value_from_member_access;
            expression_handlers[ExpressionType.Constant] = get_constant_value;
        }

        public static void trigger_event<Target>(Expression<Action<Target>> expression_representing_event_to_raise,
                                                 object target) where Target : IEventTarget
        {
            var method_call_expression = expression_representing_event_to_raise.Body.downcast_to<MethodCallExpression>();
            var method_args = get_parameters_from(method_call_expression.Arguments);
            var method_name = method_call_expression.Method.Name;
            var method = target.GetType().GetMethod(method_name, binding_flags);

            method.Invoke(target, method_args.ToArray());
        }

        static object get_constant_value(Expression expression)
        {
            return expression.downcast_to<ConstantExpression>().Value;
        }

        static object get_value_from_member_access(Expression expression)
        {
            var member_expression = expression.downcast_to<MemberExpression>();
            var type = member_expression.Member.DeclaringType;
            var member = (FieldInfo) member_expression.Member;
            var value = member.GetValue(Activator.CreateInstance(type));
            return value;
        }

        static object instantiate_value(Expression expression)
        {
            var new_expression = expression.downcast_to<NewExpression>();
            var args = new_expression.Arguments.Select(x => get_value_from_evaluating(x));
            return new_expression.Constructor.Invoke(args.ToArray());
        }

        static IEnumerable<object> get_parameters_from(IEnumerable<Expression> parameter_expressions)
        {
            foreach (var expression in parameter_expressions)
            {
                if (can_handle(expression)) yield return get_value_from_evaluating(expression);
                else cannot_handle(expression);
            }
        }

        static void cannot_handle(Expression expression)
        {
            throw new ArgumentException("cannot parse {0}".formatted_using(expression));
        }

        static object get_value_from_evaluating(Expression expression)
        {
            return expression_handlers[expression.NodeType](expression);
        }

        static bool can_handle(Expression expression)
        {
            return expression_handlers.ContainsKey(expression.NodeType);
        }
    }
}