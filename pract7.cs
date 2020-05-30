using System;
using static System.Console;
using static System.Convert;
using System.Collections;
using System.Collections.Generic;

/*int ids = ToInt32(ReadLine());
  parametrs.Add(ids);
  string fio = ReadLine();
  parametrs.Add(fio);
  int group = ToInt32(ReadLine());
  parametrs.Add(group);
  int data = ToInt32(ReadLine());
  parametrs.Add(data);*/
namespace pract5
{

    class Program
    {
        class Lib
        {
            public class Student
            {
                public int ids;
                public string fio;
                public int group;
                public string data;
            }
            public List<Student> stud = new List<Student>();

            public string funkfio(string ffio)
            {
                string realfio = "";
                for (int i = 0; i < ffio.Length; i++)
                {
                    if (ffio[i] != ' ')
                    {
                        realfio += ffio[i];
                    }
                    else break;

                }
                return realfio;
            }
            public string funkinicfio(string finfio)
            {
                string realinfio = "";
                string k1 = "", k2 = "";
                for (int i = 0; i < finfio.Length; i++)
                {
                    if (finfio[i] != ' ')
                    {
                        realinfio += finfio[i];
                    }
                    else
                    {
                        k1 += finfio[i + 1];
                        i++;
                        for(int j=i; j< finfio.Length; j++)
                        {
                            if (finfio[j] == ' ')
                            {

                                k2 += finfio[j + 1];
                                break;
                            }
                        }
                        break;
                    }
                }
                realinfio += " " + k1.ToUpper() + "." + k2.ToUpper() + ".";
                return realinfio;
            }
            public void addstud(int ids, string fio, int group, string data)
            {
                stud.Add(new Student() { ids = ids, fio = fio, group = group, data = data });
            }
            public void del(int ids)
            {
                for (int i = 0; i < stud.Count; i++)
                {
                    if (stud[i].ids == ids) stud.RemoveAt(i);
                }
            }
            public void izmen(int ids, string fio, int group, string data)
            {
                for (int i = 0; i < stud.Count; i++)
                {
                    if (stud[i].ids == ids)
                    {
                        stud[i].fio = fio;
                        stud[i].group = group;
                        stud[i].data = data;
                    }

                }
            }
            public void show()
            {
                foreach (var i in stud)
                {
                    WriteLine(i.fio + "\n");
                }
            }
            public void poiskID(int id)
            {
                WriteLine(stud[id].ids + "\n" + stud[id].fio + "\n" + stud[id].group + "\n" + stud[id].data + "\n");
            }
            public void age(int idi)
            {
                DateTime idage = ToDateTime(stud[idi].data);
                /* Console.WriteLine(thisDay.ToString("d"));*/
                DateTime now = DateTime.Today;
                int age = now.Year - idage.Year;
                if (idage > now.AddYears(-age)) age--;
                WriteLine(age + " - возраст студента.");
            }
            public void age18(string s1)
            {
                foreach (var idi18 in stud)
                {
                    DateTime idage = ToDateTime(idi18.data);
                    DateTime now = DateTime.Today;
                    int age = now.Year - idage.Year;
                    if (idage > now.AddYears(-age)) age--;
                    if (s1 == "a")
                    {
                        if (age >= 18) WriteLine("\n" + idi18.ids + "\n" + idi18.fio + "\n" + idi18.group + "\n" + idi18.data + "\n");
                    }
                    else if (s1 == "s")
                    {
                        if (age < 18) WriteLine("\n" + idi18.ids + "\n" + idi18.fio + "\n" + idi18.group + "\n" + idi18.data + "\n");
                    }
                }

            }

            public void searchFIO(string sFIO)
            {
                string tfio = "";
                foreach (var i in stud)
                {
                    tfio = funkfio(i.fio);
                    if (tfio == sFIO)
                    {
                        WriteLine("\n" + i.ids + "\n" + i.fio + "\n" + i.group + "\n" + i.data + "\n");
                    }
                }
            }
            public void inicfio(int IDstud)
            {
                WriteLine("\n" + funkinicfio(stud[IDstud].fio));
            }

            static void Main(string[] args)
            {
                Lib L = new Lib();
                int ids = 0;
                int z;
                do
                {
                    WriteLine("\nВведите: \n 1. Чтобы добавить студента \n 2. Чтобы изменить \n 3. Удалить \n 4. Вывести Ф.И.О. \n " +
                        "5. Вывести информацию по ID \n 6. Возраст выбранного по ID студента\n 7. Студенты 18+, 18-\n 8. Поиск по фамилии\n 9. Фамилия и инициалы");
                    z = ToInt32(ReadLine());
                    WriteLine("\n");
                    if (z == 1)
                    {
                        //Добавить
                        WriteLine("\nФ.И.О.: ");
                        string fio = ReadLine();
                        WriteLine("Группа: ");
                        int group = ToInt32(ReadLine());
                        WriteLine("Дата рождения дд.мм.гггг: ");
                        string data = ReadLine();
                        L.addstud(ids, fio, group, data);
                        ids++;
                    }
                    else if (z == 2)
                    {
                        //Изменить
                        WriteLine("\nID студента: ");
                        int idsT = ToInt32(ReadLine());
                        WriteLine("Ф.И.О.: ");
                        string fio = ReadLine();
                        WriteLine("Группа: ");
                        int group = ToInt32(ReadLine());
                        WriteLine("Дата рождения дд.мм.гггг: ");
                        string data = ReadLine();
                        L.izmen(idsT, fio, group, data);
                    }
                    else if (z == 3)
                    {
                        //Удалить
                        ids = ToInt32(ReadLine());
                        L.del(ids);
                    }
                    else if (z == 4) L.show(); //Показать ФИО
                    else if (z == 5)
                    {
                        WriteLine("Введите ID студента");
                        int idss = ToInt32(ReadLine());
                        L.poiskID(idss);
                    }
                    else if (z == 6)
                    {
                        WriteLine("Введите ID студента");
                        int IDage = ToInt32(ReadLine());
                        L.age(IDage);
                    }
                    else if (z == 7)
                    {
                        WriteLine("Введите 's' инфа по <18лет\nВведите 'a' инфа по >18лет: ");
                        string ss = ReadLine();
                        L.age18(ss);
                    }
                    else if (z == 8)
                    {
                        WriteLine("Введите фамилию студента: ");
                        string sFIO = ReadLine();
                        L.searchFIO(sFIO);
                    }
                    else if (z == 9)
                    {
                        WriteLine("Введите ID студента: ");
                        int IDstud = ToInt32(ReadLine());
                        L.inicfio(IDstud);
                    }

                } while (z != 0);


            }
        }
    }
}
