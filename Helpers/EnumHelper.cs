using BookStore.StableModels;

namespace BookStore.Helpers
{
    public static partial class Helper

    {
        public static T ReadEnum<T>(string caption)
            where T : Enum
        {
            Type typeOfEnum= typeof(T);
            object value;
            var color = Console.ForegroundColor;

           foreach ( var item in Enum.GetValues(typeOfEnum))
                    {
                Console.WriteLine($"{(int)item}. {item}");
            }
        l1:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(caption);
            Console.ForegroundColor = color;

            if (!Enum.TryParse(typeOfEnum, Console.ReadLine(),true, out value)
                || !Enum.IsDefined(typeOfEnum, value))
            {
                goto l1;
            }
           
            return (T) value;
        }
    }
}
