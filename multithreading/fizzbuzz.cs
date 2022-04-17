
// The SAME instance of the FizzBuzz class is used to run multiple threads.
using System.Threading;
public class FizzBuzz {
    private int n;

    private Barrier barrier;

    public FizzBuzz(int n) {
        this.n = n;
        this.barrier = new Barrier(4);
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz) {
        for (int i = 1; i <= n; i++) {
            if (i % 3 == 0 && i % 5 != 0) {
                printFizz();
            }
            barrier.SignalAndWait();
        }
    }

    // printBuzz() outputs "buzz".
    public void Buzz(Action printBuzz) {
        for (int i = 1; i <= n; i++) {
            if (i % 5 == 0 && i % 3 != 0)
            {
                printBuzz();
            }
            barrier.SignalAndWait();
        }
        
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz) {
        for (int i = 1; i <= n; i++) {
            if (i % 3 == 0 && i % 5 == 0)
            {
                printFizzBuzz();
            }
            barrier.SignalAndWait();
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber) {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 != 0 && i % 5 != 0)
            {
                printNumber(i);
            }
            barrier.SignalAndWait();
        }
    }
}