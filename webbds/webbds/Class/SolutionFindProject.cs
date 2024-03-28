using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using webbds.Models;
namespace webbds.Class
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }

        public static Specification<T> operator !(Specification<T> spec)
        {
            return new NotSpecification<T>(spec);
        }

        protected ParameterExpression CreateParameter()
        {
            return Expression.Parameter(typeof(T), "p");
        }
    }

    public static class ExpressionReplacer
    {
        public static Expression ReplaceParameter(
            Expression expression,
            ParameterExpression oldParameter,
            ParameterExpression newParameter)
        {
            return new ParameterReplacer { 
                OldParameter = oldParameter, 
                NewParameter = newParameter 
            }.Visit(expression);
        }

        private class ParameterReplacer : ExpressionVisitor
        {
            public ParameterExpression OldParameter { get; set; }
            public ParameterExpression NewParameter { get; set; }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return node == OldParameter 
                    ? NewParameter : base.VisitParameter(node);
            }
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var parameter = CreateParameter(); // Tạo tham số mới
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            // Thay thế tham số trong biểu thức của leftExpression và rightExpression
            var leftBody = ExpressionReplacer.ReplaceParameter(leftExpression.Body, leftExpression.Parameters[0], parameter);
            var rightBody = ExpressionReplacer.ReplaceParameter(rightExpression.Body, rightExpression.Parameters[0], parameter);
            // Kết hợp hai biểu thức bằng AND
            var andExpression = Expression.AndAlso(leftBody, rightBody);
            return Expression.Lambda<Func<T, bool>>(andExpression, parameter);
        }
    }

    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var parameter = CreateParameter(); // Tạo tham số mới
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();
            // Thay thế tham số trong biểu thức của leftExpression và rightExpression
            var leftBody = ExpressionReplacer.ReplaceParameter(leftExpression.Body, leftExpression.Parameters[0], parameter);
            var rightBody = ExpressionReplacer.ReplaceParameter(rightExpression.Body, rightExpression.Parameters[0], parameter);
            // Kết hợp hai biểu thức bằng AND
            var orExpression = Expression.OrElse(leftBody, rightBody);
            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters);
        }
    }

    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _spec;
        public NotSpecification(Specification<T> spec)
        {
            _spec = spec;
        }
        public override Expression<Func<T, bool>> ToExpression()
        {
            var parameter = CreateParameter(); // Tạo tham số mới
            var expression = _spec.ToExpression();
            var _specBody = ExpressionReplacer.ReplaceParameter(expression.Body, expression.Parameters[0], parameter);
            var notExpression = Expression.Not(_specBody);
            return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters);
        }
    }
    public class NameSpecification : Specification<BatDongSan>
    {
        private readonly string _name;
        public NameSpecification(string name)
        {
            _name = name;
        }
        public override Expression<Func<BatDongSan, bool>> ToExpression()
        {
            var parameter = CreateParameter();
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var body = _name == null || _name.Trim() == ""
                ? (Expression)Expression.Constant(true)
                : Expression.Call(Expression.Property(parameter, "TieuDe"), containsMethod, Expression.Constant(_name));
            return Expression.Lambda<Func<BatDongSan, bool>>(body, parameter);
        }
    }
    public class AreaSpecification : Specification<BatDongSan>
    {
        private readonly Nullable<double> _minArea;
        private readonly Nullable<double> _maxArea;
        public AreaSpecification(Nullable<double> _minArea, Nullable<double> _maxArea)
        {
            this._minArea = _minArea;
            this._maxArea = _maxArea;
        }
        public override Expression<Func<BatDongSan, bool>> ToExpression()
        {
            var parameter = CreateParameter();

            var body = (!_minArea.HasValue || !_maxArea.HasValue)
                ? (Expression)Expression.Constant(true)
                : Expression.AndAlso(
                    Expression.GreaterThan(Expression.Property(parameter, "DienTich"), Expression.Constant(_minArea)),
                    Expression.LessThanOrEqual(Expression.Property(parameter, "DienTich"), Expression.Constant(_maxArea)));

            return Expression.Lambda<Func<BatDongSan, bool>>(body, parameter);
        }
    }



}