using static Graph_Implementation___Adjacency_Matrix.Graph;

namespace Graph_Implementation___Adjacency_Matrix
{
	public class Program
	{

		static void Main(string[] args)
		{
			// Create a list of vertices with string labels
			List<string> vertices = new List<string> { "A", "B", "C", "D", "E" };


			// Create a new graph object with the specified vertices
			Graph graph1 = new Graph(vertices, enGraphDirectionType.Undirected);

			// Add some edges with default weights=1 between vertices
			graph1.AddEdge("A", "B", 1);
			graph1.AddEdge("A", "C", 1);
			graph1.AddEdge("B", "D", 1);
			graph1.AddEdge("C", "D", 1);
			graph1.AddEdge("B", "E", 1);
			graph1.AddEdge("D", "E", 1);



			// Display the adjacency matrix with weights to visualize the graph
			graph1.DisplayGraph("Adjacency Matrix for Example1 (Undirected Graph):");

			Console.WriteLine("\n------------------------------\n");

			// Create a new graph object with the specified vertices
			Graph graph2 = new Graph(vertices, enGraphDirectionType.Directed);

			// Add some edges with weights between vertices
			graph2.AddEdge("A", "A", 1);
			graph2.AddEdge("A", "B", 1);
			graph2.AddEdge("A", "C", 1);
			graph2.AddEdge("B", "E", 1);
			graph2.AddEdge("D", "B", 1);
			graph2.AddEdge("D", "C", 1);
			graph2.AddEdge("D", "E", 1);

			// Display the adjacency matrix with weights to visualize the graph
			graph2.DisplayGraph("Adjacency Matrix for Example2 (Directed Graph):");


			// Get and display the Indegree (number of edges) of vertex 'D'
			Console.WriteLine("\nInDegree of vertex D: " + graph2.GetInDegree("D"));

			// Get and display the Outdegree (number of edges) of vertex 'D'
			Console.WriteLine("\nOutDegree of vertex D: " + graph2.GetOutDegree("D"));

			Console.WriteLine("\n------------------------------\n");

			// Create a new graph object with the specified vertices
			Graph graph3 = new Graph(vertices, enGraphDirectionType.Undirected);

			// Add some edges with weights between vertices
			graph3.AddEdge("A", "B", 5);
			graph3.AddEdge("A", "C", 3);
			graph3.AddEdge("B", "D", 12);
			graph3.AddEdge("C", "D", 10);
			graph3.AddEdge("B", "E", 2);
			graph3.AddEdge("D", "E", 7);

			// Display the adjacency matrix with weights to visualize the graph
			graph3.DisplayGraph("Adjacency Matrix for Example3 (Weighted Graph):");


			// Check if there is an edge between 'A' and 'B' and display the result
			Console.WriteLine("\nIs there an edge between A and B in Graph3? " + graph3.IsEdge("A", "B"));


			// Check if there is an edge between 'A' and 'B' and display the result
			Console.WriteLine("\nIs there an edge between B and C in Graph3? " + graph3.IsEdge("B", "C"));


			// Check if there is an edge between 'A' and 'A' and display the result
			Console.WriteLine("\nIs there an edge between E and D in Graph3? " + graph3.IsEdge("E", "D"));

			// Check if there is an edge between 'A' and 'A' and display the result
			Console.WriteLine("\nIs there an edge between A and A in Graph3? " + graph3.IsEdge("A", "A"));


			// Get and display the Indegree (number of edges) of vertex 'A'
			Console.WriteLine("\nInDegree of vertex A: " + graph3.GetInDegree("A"));

			// Get and display the Indegree (number of edges) of vertex 'A'
			Console.WriteLine("\nOutDegree of vertex A: " + graph3.GetOutDegree("A"));

			Console.WriteLine("\n------------------------------\n");


			Console.WriteLine("\nRemoveing Edge between E and D:");
			// Remove the edge between 'E' and 'D'
			graph3.RemoveEdge("E", "D");

			// Display the updated adjacency matrix after removing the edge
			graph3.DisplayGraph("After Removeing Edge between E and D:");


			// Check if there is an edge between 'A' and 'A' and display the result
			Console.WriteLine("\nIs there an edge between E and D in Graph3? " + graph3.IsEdge("E", "D"));


		}
	}
}
