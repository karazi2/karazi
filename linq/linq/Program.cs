
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class realestateobject
{
    [Key]
    public int object_id { get; set; }
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<district> district { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            Console.WriteLine("Введите название района:");
            string districtName = Console.ReadLine();

            decimal minCost, maxCost;
            Console.WriteLine("Введите минимальную стоимость:");
            while (!decimal.TryParse(Console.ReadLine(), out minCost))
            {
                Console.WriteLine("Некорректное значение. Попробуйте снова:");
            }

            Console.WriteLine("Введите максимальную стоимость:");
            while (!decimal.TryParse(Console.ReadLine(), out maxCost) || maxCost <= minCost)
            {
                Console.WriteLine("Некорректное значение. Максимальная стоимость должна быть больше минимальной. Попробуйте снова:");
            }

            var query = from re in context.realestateobject
                        join d in context.district on re.district_id equals d.district_id
                        where d.district_name == districtName
                            && re.cost >= minCost && re.cost <= maxCost
                        orderby re.cost descending
                        select new
                        {
                            re.address,
                            re.area,
                            re.floor
                        };

            Console.WriteLine($"Объекты недвижимости в районе {districtName} со стоимостью от {minCost} до {maxCost} (отсортированные по убыванию стоимости):");
            foreach (var item in query)
            {
                Console.WriteLine($"Адрес: {item.address}, Площадь: {item.area}, Этаж: {item.floor}");
            }
        }
    }
}




2)
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// Модель для таблицы sale
public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public decimal cost { get; set; }
}

// Модели для таблицы realestateobject
public class realestateobject
{
    [Key]
    public int object_id { get; set; }
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    // Навигационное свойство для связи с районом
    public district district { get; set; }
    public realtor realtor { get; set; }
}

// Модель для таблицы district
public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

// Модель для таблицы realtor
public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

// Контекст базы данных
public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<sale> sale { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            Console.WriteLine("Введите количество комнат:");
            int roomCount;
            while (!int.TryParse(Console.ReadLine(), out roomCount))
            {
                Console.WriteLine("Некорректное значение. Попробуйте снова:");
            }

            var query = from sale in context.sale
                        join realestate in context.realestateobject on sale.object_id equals realestate.object_id
                        join realtor in context.realtor on sale.realtor_id equals realtor.realtor_id
                        where realestate.room_count == roomCount
                        select new
                        {
                            realestate.object_id,
                            RealtorId = realtor.realtor_id,
                            realtor.last_name,
                            realtor.first_name,
                            realtor.middle_name
                        };

            Console.WriteLine($"Риэлторы, продавшие {roomCount}-комнатные объекты недвижимости:");
            foreach (var item in query)
            {
                Console.WriteLine($"ID объекта: {item.object_id}, Фамилия: {item.last_name}, Имя: {item.first_name}, Отчество: {item.middle_name}");
            }
        }
    }
}


3)
    
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;


public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public decimal cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}
public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}
public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}
public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }


    public district district { get; set; }
    public realtor realtor { get; set; }
}
public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}
public class rating
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<rating> rating { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество комнат:");
        int roomCount;
        while (!int.TryParse(Console.ReadLine(), out roomCount))
        {
            Console.WriteLine("Некорректное значение. Попробуйте снова:");
        }

        Console.WriteLine("Введите название района:");
        string districtName = Console.ReadLine();

        using (var context = new realestatecontext())
        {
            var totalCost = context.realestateobject
                .Where(re => re.room_count == roomCount && re.district.district_name == districtName)
                .Sum(re => re.cost);

            Console.WriteLine($"Общая стоимость двухкомнатных объектов недвижимости в районе '{districtName}': {totalCost}");
        }
    }
}

4)
    
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}
public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}
public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}
public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
    public realtor realtor { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}
public class rating
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<rating> rating { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите фамилию риэлтора:");
        string lastName = Console.ReadLine();

        using (var context = new realestatecontext())
        {
            var realtor = context.realtor.FirstOrDefault(r => r.last_name == lastName);
            if (realtor == null)
            {
                Console.WriteLine("Риэлтор не найден.");
                return;
            }

            var sales = context.sale.Where(s => s.realtor_id == realtor.realtor_id).ToList();

            if (sales.Any())
            {
                var maxCost = sales.Max(s => s.cost);
                var minCost = sales.Min(s => s.cost);

                Console.WriteLine($"Максимальная стоимость объекта недвижимости, проданного риэлтором {lastName}: {maxCost}");
                Console.WriteLine($"Минимальная стоимость объекта недвижимости, проданного риэлтором {lastName}: {minCost}");
            }
            else
            {
                Console.WriteLine($"Риэлтор {lastName} не продал ни одного объекта недвижимости.");
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}
public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}
public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}
public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
    public realtor realtor { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}
public class rating
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<rating> rating { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите фамилию риэлтора:");
        string lastName = Console.ReadLine();

        using (var context = new realestatecontext())
        {
            var realtor = context.realtor.FirstOrDefault(r => r.last_name == lastName);
            if (realtor == null)
            {
                Console.WriteLine("Риэлтор не найден.");
                return;
            }

            var sales = context.sale.Where(s => s.realtor_id == realtor.realtor_id).ToList();

            if (sales.Any())
            {
                var maxCost = sales.Max(s => s.cost);
                var minCost = sales.Min(s => s.cost);

                Console.WriteLine($"Максимальная стоимость объекта недвижимости, проданного риэлтором {lastName}: {maxCost}");
                Console.WriteLine($"Минимальная стоимость объекта недвижимости, проданного риэлтором {lastName}: {minCost}");
            }
            else
            {
                Console.WriteLine($"Риэлтор {lastName} не продал ни одного объекта недвижимости.");
            }
        }
    }
}
6)
    
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите фамилию риэлтора:");
        string realtorLastName = Console.ReadLine();

        Console.WriteLine("Введите тип объекта недвижимости (например, апартаменты):");
        string propertyType = Console.ReadLine();

        Console.WriteLine("Введите критерий оценки (например, Безопасность):");
        string evaluationCriterion = Console.ReadLine();

        using (var context = new realestatecontext())
        {
            var realtor = context.realtor.FirstOrDefault(r => r.last_name == realtorLastName);
            if (realtor == null)
            {
                Console.WriteLine($"Риэлтор с фамилией {realtorLastName} не найден.");
                return;
            }

            var propertyTypeObject = context.propertytype.FirstOrDefault(pt => pt.type_name == propertyType);
            if (propertyTypeObject == null)
            {
                Console.WriteLine($"Тип объекта недвижимости {propertyType} не найден.");
                return;
            }

            var evaluationCriterionObject = context.evaluationcriteria.FirstOrDefault(ec => ec.criterion_name == evaluationCriterion);
            if (evaluationCriterionObject == null)
            {
                Console.WriteLine($"Критерий оценки {evaluationCriterion} не найден.");
                return;
            }

            var ratingsForRealtor = context.ratings
                .Where(r => r.object_id == realtor.realtor_id)
                .ToList();

            if (!ratingsForRealtor.Any())
            {
                Console.WriteLine($"Отсутствуют оценки для риэлтора {realtorLastName}.");
                return;
            }

            var averageScore = ratingsForRealtor
                .Where(r => r.criterion_id == evaluationCriterionObject.criterion_id)
                .Average(r => r.score);

            Console.WriteLine($"Средняя оценка апартаментов по критерию \"{evaluationCriterion}\" для риэлтора {realtorLastName}: {averageScore}");
        }
    }
}



using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// Модель для таблицы sale
public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    // Навигационное свойство для связи с районом
    public district district { get; set; }
    public realtor realtor { get; set; }
}

// Модель для таблицы district
public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

// Модель для таблицы realtor
public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

// Контекст базы данных
public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            Console.WriteLine("Введите тип объекта:");
            string objectType = Console.ReadLine();

            var result = context.sale
                                .Join(context.realtor, s => s.realtor_id, r => r.realtor_id, (s, r) => new { Sale = s, Realtor = r })
                                .GroupBy(sr => new { sr.Realtor.last_name, sr.Realtor.first_name, sr.Realtor.middle_name })
                                .Select(g => new
                                {
                                    RealtorFullName = $"{g.Key.last_name} {g.Key.first_name} {g.Key.middle_name}",
                                    SaleCount = g.Count()
                                })
                                .ToList();

            Console.WriteLine("ФИО риэлтора - Количество квартир");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.RealtorFullName} - {item.SaleCount}");
            }
        }
    }
}





using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            var topThreeExpensivePropertiesInDistrict = context.district
                .Include(d => d.realestateobjects)
                .Select(d => new
                {
                    DistrictName = d.district_name,
                    Properties = d.realestateobjects
                        .OrderByDescending(r => r.cost)
                        .ThenBy(r => r.floor)
                        .Take(3)
                        .Select(r => new
                        {
                            Address = r.address,
                            Cost = r.cost,
                            Floor = r.floor
                        })
                });

            foreach (var districtInfo in topThreeExpensivePropertiesInDistrict)
            {
                Console.WriteLine($"Название района: {districtInfo.DistrictName}");

                foreach (var property in districtInfo.Properties)
                {
                    Console.WriteLine($"Адрес: {property.Address}, Стоимость: {property.Cost}, Этаж: {property.Floor}");
                }

                Console.WriteLine();
            }
        }
    }
}


using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }
    public realtor realtor { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите ФИО риэлтора:");
        string realtorFullName = Console.ReadLine();

        using (var context = new realestatecontext())
        {
            var nameComponents = realtorFullName.Split(' ');
            string lastName = nameComponents[0];
            string firstName = nameComponents.Length > 1 ? nameComponents[1] : "";
            string middleName = nameComponents.Length > 2 ? nameComponents[2] : "";

            var realtor = context.realtor.FirstOrDefault(r => r.last_name == lastName && r.first_name == firstName && r.middle_name == middleName);

            if (realtor != null)
            {
                var salesByRealtor = context.sale
                                            .Where(s => s.realtor_id == realtor.realtor_id)
                                            .ToList();

                var yearsWithMoreThanTwoSales = salesByRealtor
                                                    .GroupBy(s => s.sale_date.Year)
                                                    .Where(g => g.Count() > 2)
                                                    .Select(g => g.Key)
                                                    .ToList();

                if (yearsWithMoreThanTwoSales.Any())
                {
                    Console.WriteLine($"Риэлтор {realtorFullName} продал больше 2 объектов недвижимости в следующие года:");
                    foreach (var year in yearsWithMoreThanTwoSales)
                    {
                        Console.WriteLine(year);
                    }
                }
                else
                {
                    Console.WriteLine($"Риэлтор {realtorFullName} не продал больше 2 объектов недвижимости ни в одном году.");
                }
            }
            else
            {
                Console.WriteLine($"Риэлтор с ФИО {realtorFullName} не найден.");
            }
        }
    }
}



using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public decimal cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public decimal area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }
}

public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public decimal score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            var realestateObjects = context.realestateobject.ToList();

            if (realestateObjects.Any())
            {
                var yearsWithTwoToThreeProperties = realestateObjects
      .Select(x => x.announcement_date.Year)
      .GroupBy(year => year)
      .Select(g => new
      {
          Year = g.Key,
          PropertyCount = g.Count()
      })
      .Where(x => x.PropertyCount >= 2 && x.PropertyCount <= 3)
      .OrderBy(x => x.Year)
      .ToList();

                if (yearsWithTwoToThreeProperties.Any())
                {
                    Console.WriteLine("Года с 2 или 3 объектами недвижимости:");
                    foreach (var result in yearsWithTwoToThreeProperties)
                    {
                        Console.WriteLine(result.Year);
                    }
                }
                else
                {
                    Console.WriteLine("Не найдено годов с 2 или 3 объектами недвижимости.");
                }
            }
            else
            {
                Console.WriteLine("В базе данных нет объектов недвижимости.");
            }
        }
    }
}



using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }


    public realestateobject realestateobject { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

    public ICollection<sale> sales { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            var propertiesWithin20PercentDifference = context.sale
                .Join(context.realestateobject,
                      s => s.object_id,
                      r => r.object_id,
                      (s, r) => new { Sale = s, Realestateobject = r })
                .Where(j => Math.Abs(j.Sale.cost - j.Realestateobject.cost) / j.Realestateobject.cost <= 0.2)
                .Select(j => new
                {
                    Address = j.Realestateobject.address,
                    District = j.Realestateobject.district.district_name
                });

            Console.WriteLine("Объекты недвижимости с разницей в стоимости не более 20%:");

            foreach (var property in propertiesWithin20PercentDifference)
            {
                Console.WriteLine($"Адрес: {property.Address}, Район: {property.District}");
            }
        }
    }
}



using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }

    public realestateobject realestateobject { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

    public ICollection<sale> sales { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            var averagePricePerSquareMeterByDistrict = context.realestateobject
                .GroupBy(r => r.district_id)
                .Select(g => new
                {
                    DistrictId = g.Key,
                    AveragePricePerSquareMeter = g.Average(r => r.cost / r.area)
                })
                .ToDictionary(x => x.DistrictId, x => x.AveragePricePerSquareMeter);

            var allDistricts = context.district.ToList();

            Console.WriteLine("Средняя цена за квадратный метр по району:");
            foreach (var district in allDistricts)
            {
                var districtId = district.district_id;
                var districtName = district.district_name;
                var averagePricePerSquareMeter = averagePricePerSquareMeterByDistrict.ContainsKey(districtId) ? averagePricePerSquareMeterByDistrict[districtId] : 0.0;
                Console.WriteLine($"Район: {districtName}, Средняя цена за квадратный метр: {averagePricePerSquareMeter}");
            }
            Console.WriteLine();

            Console.WriteLine("Цена каждого объекта недвижимости:");
            var allProperties = context.realestateobject.ToList();
            foreach (var property in allProperties)
            {
                var district = allDistricts.FirstOrDefault(d => d.district_id == property.district_id)?.district_name;
                Console.WriteLine($"Адрес: {property.address}, Район: {district}, Цена за квадратный метр: {property.cost / property.area}");
            }
            Console.WriteLine();

            var addressesWithLowerPricePerSquareMeter = allProperties
                .Where(r => averagePricePerSquareMeterByDistrict.ContainsKey(r.district_id) && r.cost / r.area < averagePricePerSquareMeterByDistrict[r.district_id])
                .Select(r => new
                {
                    Address = r.address,
                    District = allDistricts.FirstOrDefault(d => d.district_id == r.district_id)?.district_name // Получаем название района
                });

            Console.WriteLine("Адреса квартир с ценой за квадратный метр ниже средней по району:");

            foreach (var property in addressesWithLowerPricePerSquareMeter)
            {
                Console.WriteLine($"Адрес: {property.Address}, Район: {property.District}");
            }
        }
    }
}




using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }

    public realestateobject realestateobject { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

    public ICollection<sale> sales { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            int currentYear = DateTime.Now.Year;

            var realtorsWithNoSalesThisYear = context.realtor
                .Where(r => !context.sale.Any(s => s.realtor_id == r.realtor_id && s.sale_date.Year == currentYear))
                .Select(r => new
                {
                    FullName = $"{r.first_name} {r.middle_name} {r.last_name}"
                })
                .ToList();

            Console.WriteLine("Риэлторы, которые ничего не продали в текущем году:");

            foreach (var realtor in realtorsWithNoSalesThisYear)
            {
                Console.WriteLine(realtor.FullName);
            }
        }
    }
}



using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }

    public realestateobject realestateobject { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

    public ICollection<sale> sales { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; }
}

public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main(string[] args)
    {
        using (var context = new realestatecontext())
        {
            int currentYear = DateTime.Now.Year;

            var salesByDistrictCurrentYear = context.sale
     .Where(s => s.sale_date.Year == currentYear)
     .Join(context.realestateobject,
           s => s.object_id,
           r => r.object_id,
           (s, r) => new { DistrictName = r.district.district_name })
     .GroupBy(g => g.DistrictName)
     .Select(g => new
     {
         DistrictName = g.Key,
         SalesCount = g.Count()
     })
     .ToList();

            var previousYear = currentYear - 1;
            var salesByDistrictPreviousYear = context.sale
                .Where(s => s.sale_date.Year == previousYear)
                .Join(context.realestateobject,
                      s => s.object_id,
                      r => r.object_id,
                      (s, r) => new { DistrictName = r.district.district_name })
                .GroupBy(g => g.DistrictName)
                .Select(g => new
                {
                    DistrictName = g.Key,
                    SalesCount = g.Count()
                })
                .ToList();

            var combinedSalesByDistrict = salesByDistrictCurrentYear
                 .Select(c => new
                 {
                     DistrictName = c.DistrictName,
                     SalesCountCurrentYear = c.SalesCount,
                     SalesCountPreviousYear = salesByDistrictPreviousYear
                         .Where(p => p.DistrictName == c.DistrictName)
                         .Select(p => p.SalesCount)
                         .FirstOrDefault()
                 })
                 .ToList();

            Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-15}", "Название района", currentYear, previousYear, "Разница в %");
            foreach (var district in combinedSalesByDistrict)
            {
                int difference = district.SalesCountCurrentYear - district.SalesCountPreviousYear;
                double percentChange = (double)difference / district.SalesCountPreviousYear * 100;

                Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-15}", district.DistrictName, district.SalesCountCurrentYear, district.SalesCountPreviousYear, percentChange.ToString("0.##", CultureInfo.InvariantCulture));
            }
        }
    }
}

15)
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

// Модель для таблицы sale
public class sale
{
    [Key]
    public int sale_id { get; set; }
    public int object_id { get; set; }
    public DateTime sale_date { get; set; }
    public int realtor_id { get; set; }
    public double cost { get; set; }

    // Навигационное свойство для связи с объектом недвижимости
    public realestateobject realestateobject { get; set; }
}

public class buildingmaterial
{
    [Key]
    public int material_id { get; set; }
    public string material_name { get; set; }
}

public class evaluationcriteria
{
    [Key]
    public int criterion_id { get; set; }
    public string criterion_name { get; set; }
}

public class propertytype
{
    [Key]
    public int type_id { get; set; }
    public string type_name { get; set; }
}

public class realestateobject
{
    [Key]
    public int object_id { get; set; }

    [ForeignKey("district")]
    public int district_id { get; set; }
    public string address { get; set; }
    public int floor { get; set; }
    public int room_count { get; set; }
    public int type_id { get; set; }
    public int status { get; set; }
    public double cost { get; set; }
    public string description { get; set; }
    public int material_id { get; set; }
    public double area { get; set; }
    public DateTime announcement_date { get; set; }

    public district district { get; set; }

    public ICollection<sale> sales { get; set; }
}

public class district
{
    [Key]
    public int district_id { get; set; }
    public string district_name { get; set; }

    public ICollection<realestateobject> realestateobjects { get; set; }
}


// Модель для таблицы realtor
public class realtor
{
    [Key]
    public int realtor_id { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string middle_name { get; set; }
    public string contact_phone { get; set; }
}

public class ratings
{
    [Key]
    public int rating_id { get; set; }
    public int object_id { get; set; }
    public DateTime evaluation_date { get; set; }
    public int criterion_id { get; set; }
    public double score { get; set; } // Используем тип double
}

// Контекст базы данных
public class realestatecontext : DbContext
{
    public DbSet<realestateobject> realestateobject { get; set; }
    public DbSet<realtor> realtor { get; set; }
    public DbSet<ratings> ratings { get; set; }
    public DbSet<district> district { get; set; }
    public DbSet<sale> sale { get; set; }
    public DbSet<buildingmaterial> buildingmaterial { get; set; }
    public DbSet<evaluationcriteria> evaluationcriteria { get; set; }
    public DbSet<propertytype> propertytype { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=transport;Username=postgres;Password=1111;");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите ID объекта недвижимости:");
        if (!int.TryParse(Console.ReadLine(), out int objectId))
        {
            Console.WriteLine("Ошибка ввода.");
            return;
        }

        using (var context = new realestatecontext())
        {
            // Получаем средние оценки по каждому критерию для указанного объекта недвижимости
            var averageScores = context.ratings
                .Where(r => r.object_id == objectId)
                .GroupBy(r => r.criterion_id)
                .Select(g => new
                {
                    CriterionId = g.Key,
                    AverageScore = g.Average(r => r.score)
                })
                .ToList();

            // Создаем словарь для хранения эквивалентных текстов в соответствии с таблицей
            Dictionary<string, string> equivalentTexts = new Dictionary<string, string>
{
    {"Excellent", "from 9 to 10"},
    {"Very good", "from 8 to 9"},
    {"Good", "from 7 to 8"},
    {"Satisfactory", "from 6 to 7"},
    {"Unsatisfactory", "up to 6"}
};

            // Выводим результаты
            Console.WriteLine("{0,-20} {1,-15} {2,-20}", "Критерий", "Средняя оценка", "Текст");
            foreach (var averageScore in averageScores)
            {
                string equivalentText = GetEquivalentText(equivalentTexts, averageScore.AverageScore);
                Console.WriteLine("{0,-20} {1,-15} {2,-20}",
                    context.evaluationcriteria.FirstOrDefault(c => c.criterion_id == averageScore.CriterionId)?.criterion_name ?? "Unknown",
                    averageScore.AverageScore.ToString("0.##"),
                    equivalentText);
            }
        }
    }

    static string GetEquivalentText(Dictionary<string, string> equivalentTexts, double averageScore)
    {
        foreach (var kvp in equivalentTexts)
        {
            var range = kvp.Value.Split(new string[] { "from", "to", "up", " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).ToList();

            if (range.Count == 2)
            {
                var lowerBound = double.Parse(range[0]);
                var upperBound = double.Parse(range[1]);

                if (averageScore >= lowerBound && averageScore <= upperBound)
                    return kvp.Key;
            }
            else if (range.Count == 1 && kvp.Value.Contains("up"))
            {
                var upperBound = double.Parse(range[0]);

                if (averageScore < upperBound)
                    return kvp.Key;
            }
        }

        return "Unknown";
    }
}
