using AutoMapper;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Mvc.ViewModel;

namespace EstudoDDD.Mvc.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
