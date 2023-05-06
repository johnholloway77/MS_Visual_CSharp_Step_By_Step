/*
 Goal of this application is to look at the binary values of an integer and either inform if a bit at a specific index
is true(1) or if it is false (0).

Additionally the struct will allow the the bits to be set as true or false, changing the value of the int.
 
 */

namespace indexer
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\nThis is an exercise from chapter 16");

            int adapted = 0b0_01111110; //int is expressed in binary rather than decimal. Note the prefex "0b0"
            IntBits bits = new IntBits(adapted);

            bool peek = bits[6]; //retrieve bool at index 6
            Console.WriteLine("bits[6]=" + peek);

            bits[0] = true;
            bits[3] = false;

            Console.WriteLine($"{bits}");

        }
    }

    struct IntBits
    {
        private int bits;

        //simple construct, implemented as an expression-bodied method
        public IntBits(int initialBitValue) => bits = initialBitValue;

        //indexer

        public bool this[int index]
        {
            get => (bits & (1 << index)) != 0;
            set
            {
                if (value)  //turn the bit on if value is true; otherwise turn it off
                    bits |= (1 << index);
                else
                {
                    bits &= ~(1 << index);
                }
            }
        }

        public override string ToString()
        {
            return Convert.ToString(bits, 2);
        }

    }
}