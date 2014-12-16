using Autofac;
using tiny.review.core.RavenDb;
using tiny.review.core.Users;

namespace tiny.review.core
{
    internal class CoreDependencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UserService>()
            .As<IUserService>()
            .InstancePerLifetimeScope();

            builder.RegisterType<DbManager>()
                .InstancePerLifetimeScope();
        }
    }
}
