using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingValidation
{
    class ParkingValidation
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Parking parking = new Parking();

            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                string command = input[0];
                string ownerName = input[1];

                switch (command)
                {
                    case "register":
                        Car car = new Car(ownerName, input[2]);
                        parking.TryRegister(car);
                        break;
                    case "unregister":
                        Car carToUnregister = new Car(input[1]);

                        parking.TryUnRegister(carToUnregister);
                        break;
                }
            }
            parking.PrintParking();
        }
    }

    public class Parking
    {
        public List<Car> RegisteredCars;

        public Parking()
        {
            RegisteredCars = new List<Car>();
        }
    }

    static class ParkingOperator
    {
        public static void TryRegister(this Parking parking, Car car)
        {

            if (parking.RegisteredCars.Any(x => x.Owner == car.Owner))
            {
                string registeredLicensePlate = parking.RegisteredCars.First(x => x.Owner == car.Owner).LicenseRegistration.Number;
                Console.WriteLine($"ERROR: already registered with plate number {registeredLicensePlate}");
                return;
            }
            if (!car.LicenseRegistration.IsValid)
            {
                Console.WriteLine($"ERROR: invalid license plate {car.LicenseRegistration.Number}");
                return;
            }
            if (parking.RegisteredCars.Any(x => x.LicenseRegistration.Number == car.LicenseRegistration.Number))
            {
                Console.WriteLine($"ERROR: license plate {car.LicenseRegistration.Number} is busy");
                return;
            }
       
            parking.RegisteredCars.Add(car);
            Console.WriteLine($"{car.Owner} registered {car.LicenseRegistration.Number} successfully");
        }

        public static void TryUnRegister(this Parking parking, Car car)
        {
            if (!parking.RegisteredCars.Any(c => c.Owner == car.Owner))
            {
                Console.WriteLine($"ERROR: user {car.Owner} not found");
                return;
            }

            parking.RegisteredCars.Remove(parking.RegisteredCars.First(x => x.Owner == car.Owner));
            Console.WriteLine($"user {car.Owner} unregistered successfully");
        }

        public static void PrintParking(this Parking parking)
        {
            foreach (var car in parking.RegisteredCars)
            {
                Console.WriteLine($"{car.Owner} => {car.LicenseRegistration.Number}");
            }
        }
    }

    public class Car
    {
        public string Owner;
        public LicensePlate LicenseRegistration;

        public Car(string owner, string licensePlate)
        {
            Owner = owner;
            LicenseRegistration = new LicensePlate(licensePlate);
        }

        public Car(string owner)
        {
            Owner = owner;
        }

    }

    public class LicensePlate
    {
        public string Number;
        public bool IsValid;

        public LicensePlate(string licensePlate)
        {
            Number = licensePlate;
            IsValid = CheckIfValid(licensePlate);
        }

        public bool CheckIfValid(string licensePlate)
        {
            
            if (licensePlate.Length != 8)
            {
                return false;
            }
            else if (!CharsAreValid(licensePlate))
            {
                return false;
            }
            return true;
        }

        private static bool CharsAreValid(string licensePlate)
        {
            char[] numArr = licensePlate.ToCharArray();
            return
                IsLatinLetter(numArr[0])
                && IsLatinLetter(numArr[1])
                && IsLatinLetter(numArr[6]) 
                && IsLatinLetter(numArr[7])
                && char.IsDigit(numArr[2])
                && char.IsDigit(numArr[3])
                && char.IsDigit(numArr[4])
                && char.IsDigit(numArr[5]);
        }

        public static bool IsLatinLetter(char c)
        {
            return (c >= 'A' && c <= 'Z');
        }
    }
}
