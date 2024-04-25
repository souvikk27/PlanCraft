
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Plancraft.Domain.Specification
{
    public class SpecificationByEquals<T> : Specification<T>
    {
        public SpecificationByEquals(Guid value, Func<T, Guid> selector) : base(o => selector(o) == value) { }
    }

    public abstract class Specification<T>
    {
        protected readonly Func<T, bool> _predicate;

        protected Specification(Func<T, bool> predicate)
        {
            _predicate = predicate;
        }

        public bool IsSatisfiedBy(T entity)
        {
            return _predicate(entity);
        }

        public Specification<T> And(Specification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }

        public Specification<T> Or(Specification<T> specification)
        {
            return new OrSpecification<T>(this, specification);
        }

        public Specification<T> Not()
        {
            return new NotSpecification<T>(this);
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right) : base(o => left.IsSatisfiedBy(o) && right.IsSatisfiedBy(o))
        {
            _left = left;
            _right = right;
        }
    }

    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right) : base(o => left.IsSatisfiedBy(o) || right.IsSatisfiedBy(o))
        {
            _left = left;
            _right = right;
        }
    }

    public class NotSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _specification;

        public NotSpecification(Specification<T> specification) : base(o => !specification.IsSatisfiedBy(o))
        {
            _specification = specification;
        }
    }

}
