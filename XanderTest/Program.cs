using System;

namespace XanderTest
{
    //XK Code voor berekenen en tonen declaraties
    class Program
    {
        static void Main(string[] args)
        {
            //XK Vul patienten, dit kan evt uit database worden gehaald
            string[] patients = new string[2];
            patients[0] = new string("kid");
            patients[1] = new string("adult");

            //XK start output
            Console.WriteLine("--------------------------");
            Console.WriteLine(" ");

            //XK Haal iedere patient op
            foreach (string patient in patients)
            {
                getPatients(patient);
            }
        }

        //XK Haal patienten en leeftijd op
        static void getPatients(string patient)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            DateTime BP = new DateTime(1, 1, 1);

            if (patient == "kid")
            {
                BP = new DateTime(2002, 1, 6); ;
            }

            if (patient == "adult")
            {
                BP = new DateTime(1979, 7, 8);
            }

            //XK Datum vandaag
            var today = DateTime.Today;

            //XK Bereken leeftijd
            var age = today.Year - BP.Year;
            if (BP.Date > today.AddYears(-age)) age--;

            Console.Out.WriteLine("Naam: " + patient);
            Console.Out.WriteLine("Leeftijd: " + age);

            //XK roep verzekeraar aan
            getInsurance(patient, age);
            return;
        }

        //XK Haal gegevens verzekeraar op
        static void getInsurance(string insurance, int age)
        {
            string verzekeraar = "";
            decimal rate = 0.0m;
            decimal max = 0.0m;

            //XK Check welke verzekeraar patient heeft, kan uit database
            if (insurance == "kid")
            {
                verzekeraar = "Verzekeraar Q";
                decimal rateKid = 30.0m, rateAdult = 22.5m;
                max = 150.0m;

                //XK bereken de afspraakkosten
                if (age < 18)
                {
                    rate = rateKid;
                }
                else
                {
                    rate = rateAdult;
                }
            }

            if (insurance == "adult")
            {
                verzekeraar = "Verzekeraar Z";
                decimal rateKid = 32.5m, rateAdult = 25.0m;
                max = 125.0m;

                if (age < 18)
                {
                    rate = rateKid;
                }
                else
                {
                    rate = rateAdult;
                }
            }

            Console.Out.WriteLine("Verzekeraar: " + verzekeraar);

            //XK Haal data afspraken van patienten op
            getDates(insurance, rate, max);

            return;
        }

        //XK Haal afspraken op
        static void getDates(string patientName, decimal rate, decimal max)

        {
            //XK Vul array met afspraken van betreffende patient
            DateTime[] AP1 = new DateTime[0];

            if (patientName == "kid")
                {
                AP1 = new DateTime[5];
                AP1[0] = new DateTime(2020, 1, 3);
                AP1[1] = new DateTime(2020, 1, 4);
                AP1[2] = new DateTime(2020, 1, 7);
                AP1[3] = new DateTime(2020, 1, 9);
                AP1[4] = new DateTime(2020, 1, 12);
            }

            if (patientName == "adult")
            {
                AP1 = new DateTime[7];
                AP1[0] = new DateTime(2020, 1, 3);
                AP1[1] = new DateTime(2020, 1, 4);
                AP1[2] = new DateTime(2020, 1, 7);
                AP1[3] = new DateTime(2020, 1, 9);
                AP1[4] = new DateTime(2020, 1, 12);
                AP1[5] = new DateTime(2020, 1, 9);
                AP1[6] = new DateTime(2020, 1, 12);
            }

            var totalAfspraak = AP1.Length;

            //XK Geef elke afspraat met bedrag weer
            foreach (var afspraak in AP1)
            {
                Console.WriteLine("Afspraak: " + afspraak.ToString() + " x " + rate);
            }

            decimal declare = totalAfspraak * rate;

            Console.WriteLine("Totaal: " + declare);

            //XK Als max bereikt is, geef max bedrag verzekeraar
            if (declare > max)
            {
                Console.WriteLine("Maximum bedrag bereikt");
                declare = max;
            }
            else
            { declare = declare; }

            getDeclaration(declare);

            return;
        }

        //XK Geef declaratie weer
        static void getDeclaration(decimal declare)
        {
            Console.WriteLine("Te declaren: " + declare);
            Console.WriteLine(" ");
            Console.WriteLine("--------------------------");
            Console.WriteLine(" ");
            return;
        }   
    }
}

