namespace Graph_Implementation___Adjacency_List
{
	public class Graph
    {
		// Enum to specify the type of graph: Directed or Undirected
		public enum enGraphDirectionType
		{
			Directed,
			Undirected
		}
		// Dictionary to store the adjacency list (vertex -> list of edges)
		private Dictionary<string, List<Tuple<string, int>>> _adjacencyList;

		// Dictionary to map string vertices to their neighbors
		private Dictionary<string, int> _vertexDictionary;

		// Number of vertices in the graph
		private int _numberOfVertices;

		// Variable to store the type of graph (Directed or Undirected)
		private enGraphDirectionType _GraphDirectionType = enGraphDirectionType.Undirected;

		// Constructor: Initializes the adjacency list and the vertex mapping
		public Graph(List<string> vertices, enGraphDirectionType GraphDirectionType)
		{
			// Set the type of graph (Directed or Undirected)
			_GraphDirectionType = GraphDirectionType;

			// Set the number of vertices
			_numberOfVertices = vertices.Count;

			// Initialize the adjacency list
			_adjacencyList = new Dictionary<string, List<Tuple<string, int>>>();

			// Initialize the dictionary to map vertex names to indices
			_vertexDictionary = new Dictionary<string, int>();

			// Populate the dictionary with vertices and initialize adjacency list entries
			for (int i = 0; i < vertices.Count; i++)
			{
				_vertexDictionary[vertices[i]] = i;
				_adjacencyList[vertices[i]] = new List<Tuple<string, int>>();  // Initialize an empty list for each vertex
			}
		}
		// Method to add a weighted edge between two vertices (source and destination)
		public void AddEdge(string source, string destination, int weight)
		{
			// Check if both source and destination vertices exist in the map
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				// Add the edge from source to destination with the given weight
				_adjacencyList[source].Add(new Tuple<string, int>(destination, weight));

				// If the graph is undirected, add the reverse edge (from destination to source)
				if (_GraphDirectionType == enGraphDirectionType.Undirected)
				{
					_adjacencyList[destination].Add(new Tuple<string, int>(source, weight));  // Add reverse edge
				}
			}
			else
			{
				// If either vertex is invalid, show an error message
				Console.WriteLine($"\n\nIgnored: Invalid vertices. {source} ==> {destination}\n\n");
			}
		}

		// Method to remove an edge between two vertices
		public void RemoveEdge(string source, string destination)
		{
			// Check if both source and destination vertices exist in the map
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				// Remove the edge from source to destination
				_adjacencyList[source].RemoveAll(edge => edge.Item1 == destination);

				// If the graph is undirected, also remove the reverse edge
				if (_GraphDirectionType == enGraphDirectionType.Undirected)
				{
					_adjacencyList[destination].RemoveAll(edge => edge.Item1 == source);
				}
			}
			else
			{
				// If either vertex is invalid, show an error message
				Console.WriteLine("Invalid vertices.");
			}
		}

		// Method to display the adjacency list (graph representation)
		public void DisplayGraph(string Message)
		{
			Console.WriteLine("\n" + Message + "\n");

			// Loop through each vertex in the adjacency list
			foreach (var vertex in _adjacencyList)
			{
				Console.Write(vertex.Key + " -> ");  // Print the vertex label

				// Print all edges for the vertex
				foreach (var edge in vertex.Value)
				{
					Console.Write($"{edge.Item1}({edge.Item2}) ");  // Print destination vertex and weight
				}
				Console.WriteLine();
			}
		}

		// Method to check if there's an edge between two vertices
		public bool IsEdge(string source, string destination)
		{
			// Check if both source and destination vertices exist in the map
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				// Check if an edge exists from source to destination
				foreach (var edge in _adjacencyList[source])
				{
					if (edge.Item1 == destination)
					{
						return true;  // Edge found
					}
				}
			}

			return false;  // No edge found
		}

		// Method to get the indegree of a vertex (i.e., how many edges are connected to it (can reach it))
		public int GetInDegree(string vertex)
		{
			int inDegree = 0;  // Initialize the indegree count to zero

			// Check if the vertex exists in the map
			if (_vertexDictionary.ContainsKey(vertex))
			{
				// Loop through each vertex in the adjacency list
				foreach (var source in _adjacencyList)
				{
					// Loop through the edges of the current vertex
					foreach (var edge in source.Value)
					{
						// If the destination of the edge is the given vertex, increment the indegree
						if (edge.Item1 == vertex)
						{
							inDegree++;
						}
					}
				}
			}

			return inDegree;  // Return the total indegree of the vertex
		}

		// Method to get the outdegree of a vertex (i.e., how many edges are outgoing from it)
		public int GetOutDegree(string vertex)
		{
			int outDegree = 0;  // Initialize the outdegree count to zero

			// Check if the vertex exists in the map
			if (_vertexDictionary.ContainsKey(vertex))
			{
				// The outdegree is simply the number of edges in the adjacency list of the vertex
				outDegree = _adjacencyList[vertex].Count;
			}

			return outDegree;  // Return the total outdegree of the vertex
		}

	}
}
