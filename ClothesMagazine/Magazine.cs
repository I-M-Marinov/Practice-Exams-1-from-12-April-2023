using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color) => Clothes.Remove(Clothes.FirstOrDefault(d => d.Color == color));

        public Cloth GetSmallestCloth() => Clothes.MinBy(d => d.Size);

        public Cloth GetCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(c => c.Color == color);

            return cloth;
        }

        public int GetClothCount() => Clothes.Count;

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{Type} magazine contains:");
            var sortedList = Clothes.OrderBy(c => c.Size).ToList();
            foreach (Cloth cloth in sortedList)
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}