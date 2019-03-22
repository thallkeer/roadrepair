using System.Resources;
using ITS.MapObjects.BaseMapObject.Misc.PluginAttributes;
using ITS.MapObjects.RoadRepairingMapObject.Properties;

namespace ITS.MapObjects.RoadRepairingMapObject
{
    /// <summary>
    /// Предоставляет доступ к ресурсам плагина.
    /// </summary>
    internal class RoadRepairPanelResourceHelper : ResourceHelperAbstract, IResourceHelper
    {
        /// <summary>
        /// Создает класс, который предоставляет доступ к ресурсам плагина.
        /// </summary>
        /// <param name="toolName">Имя инструмента.</param>
        public RoadRepairPanelResourceHelper(string toolName)
            : base(toolName)
        {
        }

        protected override ResourceManager ResManager => Resources.ResourceManager;
    }
}