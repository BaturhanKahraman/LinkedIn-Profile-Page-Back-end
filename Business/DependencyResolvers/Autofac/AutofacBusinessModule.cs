using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<MemberManager>().As<IMemberService>();
            builder.RegisterType<EfMemberDal>().As<IMemberDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<EfEducationDal>().As<IEducationDal>();
            builder.RegisterType<EducationManager>().As<IEducationService>();

            builder.RegisterType<EfExperienceDal>().As<IExperienceDal>();
            builder.RegisterType<ExperienceManager>().As<IExperienceService>();


            builder.RegisterType<EfSkillDal>().As<ISkillDal>();
            builder.RegisterType<SkillManager>().As<ISkillService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
