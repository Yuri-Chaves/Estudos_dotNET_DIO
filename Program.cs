using System;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            var indexStudent = 0;
            string userOption = takeUserOption();

            while (userOption != "4")
            {
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do Aluno:");
                        Student student = new Student();
                        student.name = Console.ReadLine();
                        Console.WriteLine("");

                        Console.WriteLine("Informe a nota do Aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out decimal grade)){
                            student.grade = grade;
                        }else{
                            throw new ArgumentException("O Valor da nota deve ser Decimal");
                        }  

                        students[indexStudent] = student;
                        indexStudent ++;  

                        break;
                    case "2":
                        foreach(var s in students){
                            if(!string.IsNullOrEmpty(s.name)){
                                Console.WriteLine($"Aluno: {s.name}, Nota:{s.grade}");
                            }
                        }
                        break;
                    case "3":
                        decimal gradeTotal = 0;
                        var studentsTotal = 0;
                        for(int i = 0; i < students.Length; i++){
                            if(!string.IsNullOrEmpty(students[i].name)){
                                gradeTotal += students[i].grade;
                                studentsTotal++;
                            }
                        }
                        var averageGeneral = gradeTotal / studentsTotal;
                        Console.WriteLine($"Média total: {averageGeneral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                takeUserOption();
            }
        }

        private static string takeUserOption()
        {
            Console.WriteLine("");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("4- Sair");
            Console.WriteLine("");

            string userOption = Console.ReadLine();
            Console.WriteLine("");

            return userOption;
        }
    }
}
