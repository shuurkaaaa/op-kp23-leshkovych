using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome
{
    public partial class Form1 : Form //. Фрагмент коду створює необхідні змінні та списки для подальшої роботи з об'єктами типу Horse
    {//Цей фрагмент коду програми "Іподром" починається з оголошення декількох змінних та створення необхідних списків
        Horse h;//Змінна h використовується для створення об'єкту типу Horse, який представляє кіней на іподромі. Вона поки що не має присвоєної значення.
        List <Horse> horses = new List <Horse> ();//Список horses створюється з використанням типу List<Horse>. Він призначений для зберігання об'єктів типу Horse. У даному випадку, список ініціалізується порожнім.
        List<string> names = new List<string>//• Список names є списком рядків типу List<string>. Він містить список імен для кіней на іподромі. Імена заповнені заздалегідь заданими значеннями
         {
         "Alice", "Bob", "Charlie", "David", "Eleanor", "Frank", "Grace", "Henry", "Isabella", "Jack",
         "Kate", "Liam", "Mia", "Noah", "Olivia", "Patrick", "Quinn", "Ruby", "Samuel", "Tessa"
         };
        List<HorseResult> horseResults = new List <HorseResult> ();//Список horseResults є списком об'єктів типу HorseResult. Його призначення полягає у зберіганні результатів змагань кіней.
        int finished;//• Змінна finished є цілочисельною змінною та відображає кількість кіней, які закінчили змагання.


        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b;
        Graphics g;
        Random r = new Random();

        void Start()//
        {//Фрагмент коду створює та ініціалізує об'єкти Horse з випадковими значеннями для радіусу

            b = new Bitmap(1200,500);//Створюється новий об'єкт Bitmap з розмірами 1200 на 500 пікселів. Цей об'єкт Bitmap представляє зображення, на якому будуть відображатись об'єкти гри.
            g = Graphics.FromImage(b);//Створюється об'єкт Graphics з цього зображення. Він дозволяє виконувати операції малювання та рендерингу на зображенні.
            int radius;//
            double angle, speed;//
            horses.Clear();//
            for (int i = 0; i < 5;i++)
            {
                radius = r.Next(180, 220);///• Змінна radius отримує випадкове значення в діапазоні від 180 до 220. Це визначає радіус кола, по якому будуть рухатись кіні.
                speed = 0.1 * r.Next(5, 10)*0.1;//• Змінна speed отримує випадкове значення в діапазоні від 0.5 до 0.9. Це визначає швидкість руху кіней
                angle = 0;//• Змінна angle ініціалізується значенням 0. Вона представляє кут, під яким кінь буде рухатись по колу.
                h = new Horse(500, 400, 50, 50, speed, Image.FromFile("1.png"),// что это?
                    names[r.Next(0, names.Count)], angle, radius);
                horses.Add(h);
            }



            //Цей фрагмент коду створює та ініціалізує об'єкти Horse з випадковими значеннями для радіусу, швидкості та інших параметрів. Це дозволяє створити декілька кіней з різними властивостями та початковими умовами для подальшого руху по колу на іподромі.



            //У цьому фрагменті коду розглядається обробка руху кіней на іподромі, оновлення візуалізації та оновлення даних в таблиці.
            horseResults.Clear();//• horseResults.Clear() очищає список horseResults, що зберігає результати змагань кіней.
            comboBox1.Items.Clear();//очищає вміст елементів у comboBox1. Це виконується для підготовки до заповнення комбінованого списку з іменами кіней.

            foreach (Horse h in horses)
            {
                h.Move(600, 250, isOvertake(h));//Викликається метод Move, який відповідає за рух кіней. Метод отримує цільові координати (600, 250) та значення isOvertake(h), що вказує, чи потрібно виконувати обгін для даного кінька.
                h.Drow(g);//Викликається метод Drow, який відповідає за візуалізацію кіней на графічному контексті g
                horseResults.Add(h.GetResult());//• Результати кіней додаються до списку horseResults.
                comboBox1.Items.Add(h.name);//Імена кіней додаються до комбінованого списку comboBox1.
            }

            dataGridView2.DataSource = horseResults;//• dataGridView2.DataSource = horseResults прив'язує список horseResults до даних таблиці dataGridView2. Це дозволяє відображати результати змагань кіней у вигляді таблиці.
            dataGridView2.Refresh();//оновлює відображення таблиці dataGridView2 з новими даними.
            // so Цей фрагмент коду виконує процес оновлення руху кіней на іподромі, оновлення візуального представлення та оновлення даних таблиці з результатами змагань.
        }



        //. Цей фрагмент коду описує подію timer1_Tick, яка виконується при кожному тіку таймера.
        private void button1_Click(object sender, EventArgs e)//В цій події відбувається оновлення руху кіней, візуалізація, оновлення даних таблиці та перевірка на закінчення змагання.
        {
            button1.Enabled = false;
            button2.Enabled = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            g.Clear(Color.White);//очищає графічний контекст g шляхом заповнення його білим кольором. Це дозволяє очистити попередні візуальні елементи, щоб малювати новий стан.
            horseResults.Clear();//очищає список horseResults, що зберігає результати змагань кіней.

            finished = 0;//Змінна finished ініціалізується значенням 0. Вона використовується для підрахунку кількості закінчених змагань.
            foreach (Horse h in horses)
            {
                h.Move(400, 200,isOvertake(h));//Викликається метод Move, який відповідає за рух кіней. Метод отримує цільові координати (400, 200) та значення isOvertake(h), що вказує, чи потрібно виконувати обгін для даного кінька.
                h.Drow(g);//Викликається метод Drow, який відповідає за візуалізацію кіней на графічному контексті g.
                horseResults.Add(h.GetResult());//Результати кіней додаються до списку horseResults.
                if (h.isFinished) finished++;//Якщо кінь закінчив змагання (h.isFinished), збільшується лічильник закінчених змагань finished.
            }
 
            pictureBox1.Image = b;//оновлює зображення на pictureBox1 з використанням зображення b, яке містить візуалізований стан кіней.
            pictureBox1.Refresh();//оновлює відображення pictureBox1.

            horseResults = horseResults.OrderBy(p => p.leftToFinish).ToList();//сортує список horseResults за залишком відстані до фінішу (leftToFinish) в порядку зростання.

            if (finished == horses.Count)
            {//перевіряє, чи всі кіні закінчили змагання. Якщо так, виконується наступне:
                timer1.Stop();//Зупиняється таймер 
                horseResults = horseResults.OrderBy(p => p.time).ToList();//Сортується список horseResults за часом (time) в порядку зростання.
                button1.Enabled = true;//Активуються кнопки button1 і button2.
                button2.Enabled = true;
                if (comboBox1.Text == dataGridView2.Rows[0].Cells[0].Value.ToString())//Перевіряється, чи обраний кінь (comboBox1.Text) співпадає з першим рядком в стовпці "Name" 
                {
                    MessageBox.Show("Перемога");//таблиці dataGridView2. Якщо так, виводиться повідомлення "Перемога" 
                }
            }
           
            dataGridView2.DataSource = horseResults;
            dataGridView2.Refresh();//оновлює відображення таблиці dataGridView2 з новими даними.
                                    //прив'язує список horseResults до даних таблиці dataGridView2. Це оновлює відображення результатів змагань у таблиці.
        }

        bool isOvertake(Horse myH)
        {//У цьому фрагменті коду визначена функція isOvertake, яка перевіряє, чи відбувається обгін між конкретним кінем myH та іншими кіньми у списку horses.
            Horse found = horses.Find(p=>p.rec.IntersectsWith(myH.rec) && p!=myH);
            //метод Find для пошуку першого кінька found у списку horses, для якого виконується умова:

            if (found != null)//Прямокутники rec (припущення: вони представлені як об'єкти типу Rectangle) кіньків myH та p перетинаються (IntersectsWith).
            {//Кінь p не є тим самим кіньком, що і myH (p != myH).
                //Якщо знайдено такий кінь found, виконується наступне:
                return true;//Повертається значення true, що вказує на те, що відбувається обгін
            }
            else//Якщо ж жодного кінька не знайдено,
            {
                return false;//Повертається значення false, що вказує на відсутність обгону.
            }
            //Ця функція допомагає визначати, чи відбувається обгін між конкретним кінем myH та іншими кіньми на іподромі.
        }



        //У цьому фрагменті коду описані дві події, пов'язані з формою (Form1).
        private void Form1_Load(object sender, EventArgs e)
        {//Ця подія виникає при завантаженні форми. У цьому випадку, коли форма завантажується, викликається метод Start(). Це означає, що при відкритті форми починається змагання на іподромі.
            Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {//Ця подія виникає при натисканні на кнопку з ім'ям button2. У цьому випадку, коли кнопка натиснута, таймер timer1 зупиняється за допомогою timer1.Stop(), а потім викликається метод Start(). Це дозволяє зупинити поточне змагання та розпочати нове, коли користувач натискає кнопку.
            timer1.Stop();
            Start();
        }//Ці події забезпечують ініціалізацію та рестарт змагання на іподромі відповідно до потреб користувача.
    }

   
}
