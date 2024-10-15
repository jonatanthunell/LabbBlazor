namespace LabbBlazor
{
    public class SampleToDoData
    {
        public List<ToDo> ToDos { get; set; }
        public SampleToDoData()
        {
            ToDos = new List<ToDo>();
            ToDos.Add(new ToDo(1, 1, "sample todo", false));
            ToDos.Add(new ToDo(2, 2, "sample todo", false));
            ToDos.Add(new ToDo(3, 3, "sample todo", false));
            ToDos.Add(new ToDo(4, 4, "sample todo", false));
            ToDos.Add(new ToDo(5, 5, "sample todo", false));
            ToDos.Add(new ToDo(6, 6, "sample todo", false));
            ToDos.Add(new ToDo(7, 7, "sample todo", false));
            ToDos.Add(new ToDo(8, 8, "sample todo", false));
            ToDos.Add(new ToDo(9, 9, "sample todo", false));
            ToDos.Add(new ToDo(10, 10, "sample todo", false));
        }
    }
}
