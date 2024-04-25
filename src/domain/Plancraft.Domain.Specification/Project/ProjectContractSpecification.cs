

using Plancraft.Domain.Models;

namespace Plancraft.Domain.Specification.Project
{
    public class ProjectContractSpecification : SpecificationByEquals<Contract>
    {
        public ProjectContractSpecification(Guid value) : base(value, p => p.Project.ProjectId) { }
    }
}
