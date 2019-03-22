using System.Configuration;
using System.Linq;
using ITS.MapObjects.EditBaseDictionariesPlugin;
using ITS.MapObjects.EditBaseDictionariesPlugin.ViewInterfaces.Organizations;
using ITS.MapObjects.RoadRepairingMapObject.Properties;
using Microsoft.Practices.Unity;

namespace ITS.MapObjects.RoadRepairingMapObject
{
    /// <summary>
    /// Предоставляет доступ к константам и свойствам плагина.
    /// </summary>
    internal static class RoadRepairConstants
    {
        #region Private Fields

        /// <summary>
        /// Название плагина дружественное пользователю (backing storage).
        /// </summary>
        private static string _toolName;

        /// <summary>
        /// Включен ли кастомный рендерер (backing storage).
        /// </summary>
        private static bool? _customRendererEnabled;

        #endregion

        #region Properties

        /// <summary>
        /// Название плагина дружественное пользователю.
        /// </summary>
        internal static string ToolName
        {
            get
            {
                if (string.IsNullOrEmpty(_toolName))
                {
                    _toolName = Resources.PluginToolName;
                }
                return _toolName;
            }
        }

        /// <summary>
        /// Включен ли кастомный рендерер.
        /// </summary>
        internal static bool CustomRendererEnabled
        {
            get
            {
                if (!_customRendererEnabled.HasValue)
                {
                    bool res = false;
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("RoadRepairCustomRendererEnabled"))
                        bool.TryParse(ConfigurationManager.AppSettings["RoadRepairCustomRendererEnabled"], out res);
                    _customRendererEnabled = res;
                }
                return _customRendererEnabled.Value;
            }
        }

        /// <summary>
        /// IoC-контейнер плагина.
        /// </summary>
        internal static IUnityContainer Container => ProjectBase.Utils.Container.Container.PluginContainer(ToolName);

        internal static string RrepAttributeName => "rr";

        internal static ISelectOrganizationView OrganizationView { get; set; }
        public static bool IsDrawInProgress= true;
        public static bool IsDrawMade = true;
        public static bool IsDrawWillBeMade = true;
        #endregion
    }
}