using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChangingImage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> ProductList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ProductList = new List<Product>();
            Product product = new Product()
            {
                Title = "Ручка гелевая",
                ImageSources = new List<ImageSource>()
                {
                    new ImageSource(){Path="res/1_1.jpg"},
                    new ImageSource(){Path="res/2_1.jpg"},
                    new ImageSource(){Path="res/3_1.jpg"},
                    new ImageSource(){Path="res/4_1.jpg"},
                    new ImageSource(){Path="res/5_1.jpg"}
                }
            };
            ProductList.Add(product);
            DataContext = this;
        }

        private void ListBox_MouseMove(object sender, MouseEventArgs e)
        {
            ListBox listBox = sender as ListBox;
            int countElements = listBox.Items.Count;
            int numberPhoto = (int)e.GetPosition((IInputElement)listBox).X / (250 / countElements); // Делим позицию мыши относительно элемента по X на промежуток, под количество пространства, которое отводится для одного изоюражения (250 - ширина контейнера, countElements - количество картинок). Получаем индекс отображаемой картинки.
            listBox.SelectedIndex = numberPhoto;
        }
        private void ListBox_MouseLeave(object sender, MouseEventArgs e) => (sender as ListBox).SelectedIndex = 0; //если курсор ушел за приделы контейнера изображений - выделяем первую картинку
    }
}
