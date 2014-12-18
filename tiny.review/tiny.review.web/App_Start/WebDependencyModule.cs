using Autofac;
using tiny.review.web.Manager;

namespace tiny.review.web.App_Start
{
    public class WebDependencyModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AuthenticationManager>()
             .As<IAuthenticationManager>()
             .InstancePerLifetimeScope();
        }
    }
}