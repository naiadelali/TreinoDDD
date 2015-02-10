using AutoMapper;
using EstudoDDD.Dominio.Entidades;
using EstudoDDD.Mvc.ViewModel;

namespace EstudoDDD.Mvc.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
        }
    }
}
