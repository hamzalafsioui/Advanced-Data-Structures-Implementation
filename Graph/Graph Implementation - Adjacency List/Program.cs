using static Graph_Implementation___Adjacency_List.Graph;

namespace Graph_Implementation___Adjacency_List
{
	public class Program
	{
		static void Main(string[] args)
		{
			// Create a list of vertices with string labels
			List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };

			// Example 1 
			Graph graph1 = new Graph(vertices, enGraphDirectionType.Undirected);

			// Add some edges with default weights=1 between vertices
			graph1.AddEdge("A", "B", 1);
			graph1.AddEdge("A", "C", 1);
			graph1.AddEdge("B", "D", 1);
			graph1.AddEdge("C", "D", 1);
			graph1.AddEdge("B", "E", 1);
			graph1.AddEdge("D", "E", 1);

			// Display the adjacency list to visualize the graph
			graph1.DisplayGraph("Adjacency List for Example1 (Undirected Graph):");

			Console.WriteLine("\n------------------------------\n");

			// Example 2 
			Graph graph2 = new Graph(vertices, enGraphDirectionType.Directed);

			// Add some edges with weights between vertices
			graph2.AddEdge("A", "A", 1);
			graph2.AddEdge("A", "B", 1);
			graph2.AddEdge("A", "C", 1);
			graph2.AddEdge("B", "E", 1);
			graph2.AddEdge("D", "B", 1);
			graph2.AddEdge("D", "C", 1);
			graph2.AddEdge("D", "E", 1);

			// Display the adjacency list to visualize the graph
			graph2.DisplayGraph("Adjacency List for Example2 (Directed Graph):");

			// Get and display the indegree and outdegree of vertex 'D'
			Console.WriteLine("\nInDegree of vertex D: " + graph2.GetInDegree("D"));
			Console.WriteLine("\nOutDegree of vertex D: " + graph2.GetOutDegree("D"));

			Console.WriteLine("\n------------------------------\n");

			// Example 3 
			Graph graph3 = new Graph(vertices, enGraphDirectionType.Undirected);

			// Add some edges with weights between vertices
			graph3.AddEdge("A", "B", 5);
			graph3.AddEdge("A", "C", 3);
			graph3.AddEdge("B", "D", 12);
			graph3.AddEdge("C", "D", 10);
			graph3.AddEdge("B", "E", 2);
			graph3.AddEdge("D", "E", 7);

			// Display the adjacency list to visualize the graph
			graph3.DisplayGraph("Adjacency List for Example3 (Weighted Graph):");

			// Check if there is an edge between 'A' and 'B' and display the result
			Console.WriteLine("\nIs there an edge between A and B in Graph3? " + graph3.IsEdge("A", "B"));

			// Remove the edge between 'E' and 'D'
			graph3.RemoveEdge("E", "D");

			// Display the updated adjacency list after removing the edge
			graph3.DisplayGraph("After Removing Edge between E and D:");
		}
	}
}
