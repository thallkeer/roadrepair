using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ITS.MapObjects.RoadRepairingMapObject.IViews
{
    /// <summary>
    /// Базовый интерфейс вида.
    /// </summary>
    public interface IBaseView
    {
        /// <summary>
        /// Виден ли вид.
        /// </summary>
        bool IsViewVisible { get; }

        /// <summary>
        /// Показывает вид модально.
        /// </summary>
        DialogResult ShowViewDialog();

        /// <summary>
        /// Показывает вид.
        /// </summary>
        void ShowView();

        /// <summary>
        /// Закрывает вид.
        /// </summary>
        void CloseView();

        /// <summary>
        /// Вид начал показываться.
        /// </summary>
        event Action ViewShowing;

        /// <summary>
        /// Закрытие вида
        /// </summary>
        event Action ViewClosing;
    }
}