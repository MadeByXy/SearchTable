using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;

namespace WpfControlLibrary
{
    public class Loading : Control
    {
        static Loading()
        {
            //重载默认样式
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Loading), new FrameworkPropertyMetadata(typeof(Loading)));
            //DependencyProperty 注册 FillColor
            FillColorProperty = DependencyProperty.Register("FillColor",
            typeof(Color),
            typeof(Loading),
            new UIPropertyMetadata(Colors.DarkGray,
            new PropertyChangedCallback(OnUriChanged))
            );
            //Colors.DarkBlue为控件初始化默认值

        }
        //属性变更回调函数
        private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        #region 自定义Fields
        // DependencyProperty属性定义 FillColorProperty=FillColor+Property组成
        public static readonly DependencyProperty FillColorProperty;
        #endregion
        //VS设计器属性支持
        [Description("背景色"), Category("个性配置"), DefaultValue("#FF668899")]
        public Color FillColor
        {
            //GetValue,SetValue为固定写法，此处一般不建议处理其他逻辑
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
    }
}