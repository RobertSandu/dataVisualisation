using Abp.Web.Mvc.Views;

namespace proiectLicenta.Web.Views
{
    public abstract class proiectLicentaWebViewPageBase : proiectLicentaWebViewPageBase<dynamic>
    {

    }

    public abstract class proiectLicentaWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected proiectLicentaWebViewPageBase()
        {
            LocalizationSourceName = proiectLicentaConsts.LocalizationSourceName;
        }
    }
}