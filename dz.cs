using System;
using System.Xml.Serialization;
using System.IO;

// ***********************
// Студент: Устинов И.И. 
// Группа: ИУ6-71Б 
// Вариант: B 1
// ***********************


namespace ApplicationHomework
{ 
    // Тип локомотива (тепловой/электровоз)
    public enum LocoType
    {
        thermal,
        electric
    }

    // Тип вагона (пассажирский/товарный)
    public enum WagonType
    {
        Passenger,
        Trade
    }


    [Serializable]
    public class Wagon
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public WagonType WagonType { get; set; }
        public int LiftingCapacity  { get;set } // Грузоподъемность
        public int Seats { get;set } 

        public Wagon() { }
        public Wagon(string name, int serialNumber, WagonType wagonType, int seats, int liftingCapacity)
        {
            Name = name;
            SerialNumber = serialNumber;
            WagonType = wagonType;
            Seats = seats;
            LiftingCapacity = liftingCapacity;
        }
    }

    [Serializable]
    public class Loco
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public LocoType LocoType { get; set; }

        public Loco() { }
        public Loco(string name, int serialNumber, LocoType locoType)
        {
            Name = name;
            SerialNumber = serialNumber;
            LocoType = locoType;
        }
    }

    [Serializable]
    public class Train
    {
        public int  Number { get; set; }
        public Loco TrainLoco { get; set; }
        public Wagon[] Wagons { get; set; }

        public Train() { }
        public Train(int number, Loco trainLoco, Wagon[] wagons)
        {
            Number = number;
            TrainLoco = trainLoco;
            Wagons = wagons
        }
    }

 class Program
    {
        static void Main(string[] args)
        {
            var wagon1 = new Wagon("Sirius", 1, WagonType.Passenger, 100, 0);
            var wagon2 = new Wagon("Centrano", 2, WagonType.Trade, 0, 10);
            Wagon[] wagons = new Wagon[] { wagon1, wagon2 };

            var loco = new Loco("Lesser", 10, LocoType.thermal);
            var train = new Train(3, loco, wagons);

            XmlSerializer formatter = new XmlSerializer(typeof(Train));

            using (FileStream fs = new FileStream("train.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, train);
            }
        }
    }
}
}