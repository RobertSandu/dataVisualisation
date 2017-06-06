using Abp.Application.Navigation;
using Abp.Localization;
using proiectLicenta.Authorization;

namespace proiectLicenta.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class proiectLicentaNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", proiectLicentaConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Tenants",
                        L("Tenants"),
                        url: "#tenants",
                        icon: "fa fa-globe",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "About",
                        new LocalizableString("About", proiectLicentaConsts.LocalizationSourceName),
                        url: "#/about",
                        icon: "fa fa-info"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Clasificare TIOBE",
                        new LocalizableString("Clasificare TIOBE", proiectLicentaConsts.LocalizationSourceName),
                        url: "#",
                        icon: "fa fa-info"
                        ).AddItem(
                            new MenuItemDefinition(
                                "Clasificare TIOBE Multiline Series",
                                new LocalizableString("Clasificare TIOBE Multiline Series", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/vizualizareClasificareTIOBEMultilineSeries",
                                icon: "fa fa-info"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Clasificare TIOBE Donut Chart",
                                new LocalizableString("Clasificare TIOBE Donut Chart", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/vizualizareClasificareTIOBEDonutChart",
                                icon: "fa fa-info"
                                )
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        "Stack Overflow",
                        new LocalizableString("Stack Overflow", proiectLicentaConsts.LocalizationSourceName),
                        url: "#",
                        icon: "fa fa-stack-overflow"
                        ).AddItem(
                            new MenuItemDefinition(
                                "Clasificare Tag-uri",
                                new LocalizableString("Clasificare Tag-uri", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/vizualizareClasificareTaguriStackOverflow",
                                icon: "fa fa-info"
                                )
                        )
                        
                        .AddItem(
                            new MenuItemDefinition(
                                "Vizualizare utilizatori Statele Unite",
                                new LocalizableString("Vizualizare utilizatori Statele Unite", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/vizualizareUtilizatoriStateleUnite",
                                icon: "glyphicon glyphicon-globe"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Vizualizare utilizatori global",
                                new LocalizableString("Vizualizare utilizatori global", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/vizualizareUtilizatoriGlobal",
                                icon: "glyphicon glyphicon-globe"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Raspunsuri per ora",
                                new LocalizableString("Raspunsuri per ora", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/answersPerHour",
                                icon: "fa fa-users"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Raspunsuri per ora",
                                new LocalizableString("Raspunsuri per zi", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/answersPerDay",
                                icon: "fa fa-users"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Raspunsuri per ora",
                                new LocalizableString("Raspunsuri per zi si ora", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/answersPerDayAndHour",
                                icon: "fa fa-users"
                                )
                        )

                )
                .AddItem(new MenuItemDefinition(
                        "Evenimente Github",
                        new LocalizableString("Evenimente Github", proiectLicentaConsts.LocalizationSourceName),
                        url: "#",
                        icon: "fa fa-github"
                        ).AddItem(
                            new MenuItemDefinition(
                                "Cele mai urmarite repouri",
                                new LocalizableString("Cele mai urmarite repouri", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/mostWatchedGithubRepos",
                                icon: "fa fa-github-alt"
                                )
                        )
                        .AddItem(
                            new MenuItemDefinition(
                                "Cele mai ramificate (forked) repouri",
                                new LocalizableString("Cele mai ramificate (forked) repouri", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/mostForkedGithubRepos",
                                icon: "fa fa-github-square"
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                "Cele mai multe tichete",
                                new LocalizableString("Cele mai multe tichete", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/mostIssuesGithubRepos",
                                icon: "fa fa-git"
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                "Cei mai multi membri",
                                new LocalizableString("Cei mai multi membri", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/mostMembersGithubRepos",
                                icon: "fa fa-users"
                                )
                        ).AddItem(
                            new MenuItemDefinition(
                                "Statistici Github",
                                new LocalizableString("Statistici Github", proiectLicentaConsts.LocalizationSourceName),
                                url: "#/githubStatistics",
                                icon: "fa fa-table"
                                )
                        ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, proiectLicentaConsts.LocalizationSourceName);
        }
    }
}
