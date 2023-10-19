
using System.Text;

Queue<int> timeToComplete = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

Stack<int> numberOfTasks = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));

int vaderDuck = 0;
int thorDuck = 0;
int blueRubberDucky = 0;
int smallYellowDucky = 0;


while (timeToComplete.Any() && numberOfTasks.Any())
{
    int time = timeToComplete.Dequeue();
    int task = numberOfTasks.Pop();

    int calculatedTime = time * task;

    if (calculatedTime > 0 && calculatedTime <= 60)
    {
        vaderDuck++;
    }
    else if (calculatedTime > 61 && calculatedTime <= 120)
    {
        thorDuck++;
    }
    else if (calculatedTime > 121 && calculatedTime <= 180)
    {
        blueRubberDucky++;
    }
    else if (calculatedTime > 181 && calculatedTime <= 240)
    {
        smallYellowDucky++;
    }
    else
    {
        task -= 2;
        numberOfTasks.Push(task);
        timeToComplete.Enqueue(time);
    }
}

if (!numberOfTasks.Any() && !timeToComplete.Any())
{
    Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
}

StringBuilder sb = new StringBuilder();
sb.AppendLine($"Darth Vader Ducky: {vaderDuck}");
sb.AppendLine($"Thor Ducky: {thorDuck}");
sb.AppendLine($"Big Blue Rubber Ducky: {blueRubberDucky}");
sb.AppendLine($"Small Yellow Rubber Ducky: {smallYellowDucky}");

Console.WriteLine(sb);



