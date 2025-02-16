namespace Graph_Implementation___Adjacency_Matrix
{
	public class Graph
	{

		public enum enGraphDirectionType
		{
			Directed,
			Undirected
		}

		// Adjacency matrix to store the weights of edges between vertices
		private int[,] _adjacencyMatrix;

		// Dictionary to map string vertices to integer indices for adjacency matrix
		private Dictionary<string, int> _vertexDictionary;
		// Number of vertices in the graph
		private int _numberOfVertices;
		private enGraphDirectionType _graphDirectionType = enGraphDirectionType.Undirected;

		// Constructor: Initializes the adjacency matrix and the vertex mapping
		public Graph(List<string> vertices, enGraphDirectionType enGraphDirectionType)
		{
			_graphDirectionType = enGraphDirectionType;
			// Set the number of vertices
			_numberOfVertices = vertices.Count;
			// Initialize a 2D array (matrix) of size vertices x vertices
			_adjacencyMatrix = new int[_numberOfVertices, _numberOfVertices];
			// Initialize the dictionary to map vertex names to matrix indices
			_vertexDictionary = new Dictionary<string, int>();

			// Populate the dictionary with vertices (e.g., 'A' -> 0, 'B' -> 1, etc.)
			for (int i = 0; i < _numberOfVertices; i++)
			{
				_vertexDictionary[vertices[i]] = i;
			}
		}

		// Method to add a weighted edge between two vertices (source and destination)
		public void AddEdge(string source, string destination, int weight)
		{
			// Check if both source and destination vertices exist in the map
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				// Retrieve the indices for the source and destination vertices
				int sourceIndex = _vertexDictionary[source];
				int destinationIndex = _vertexDictionary[destination];
				// Set the matrix value to the weight for  [sourceIndex, destinationIndex] : one way
				_adjacencyMatrix[sourceIndex, destinationIndex] = weight;
				//Set the matrix value to the weight for  [destinationIndex,sourceIndex ] : Two ways incase of undirected graph
				if (_graphDirectionType == enGraphDirectionType.Undirected)
				{
					_adjacencyMatrix[destinationIndex, sourceIndex] = weight;
				}
			}
			else
			{
				// If either vertex is invalid, show an error message
				Console.WriteLine($"\n\nIgnored: Invalid vertices. {source} ==> {destination}");
			}
		}

		// Method to remove an edge between two vertices
		public void RemoveEdge(string source, string destination)
		{
			// Check if both source and destination vertices exist in the map
			if (_vertexDictionary.ContainsKey(source) && _vertexDictionary.ContainsKey(destination))
			{
				// Retrieve the indices for the source and destination vertices
				int sourceIndex = _vertexDictionary[source];
				int destinationIndex = _vertexDictionary[destination];
				// Set the matrix value to 0 for [sourceIndex, destinationIndex] : one way
				_adjacencyMatrix[sourceIndex, destinationIndex] = 0;
				// Set the matrix value to 0 for [destinationIndex, sourceIndex] : Two ways incase of undirected graph
				if (_graphDirectionType == enGraphDirectionType.Undirected)
				{
					_adjacencyMatrix[destinationIndex, sourceIndex] = 0;
				}
			}
			else
			{
				// If either vertex is invalid, show an error message
				Console.WriteLine($"\n\nIgnored: Invalid vertices. {source} ==> {destination}");
			}
		}

		// Method to display the adjacency matrix (graph representation) with string labels
		public void DisplayGraph(string message, int space = 4)
		{
			Console.WriteLine($"\n\n{message}");
			// Print the header row (vertex labels)
			Console.Write("".PadRight(space));
			foreach (var vertex in _vertexDictionary)
			{
				Console.Write($"{vertex.Key}".PadRight(space));
			}
			Console.WriteLine();
			// Print the matrix rows
			for (int i = 0; i < _numberOfVertices; i++)
			{
				// Print the vertex label for each row
				Console.Write($"{_vertexDictionary.ElementAt(i).Key}".PadRight(space));
				// Print the values for each row
				for (int j = 0; j < _numberOfVertices; j++)
				{
					// Print the value at _adjacencyMatrix[source.Value, j]
					Console.Write($"{_adjacencyMatrix[i, j]}".PadRight(space));
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
				int sourceIndex = _vertexDictionary[source];
				int destinationIndex = _vertexDictionary[destination];
				//if weight >0 this means there is an edge between two verticies.
				return _adjacencyMatrix[sourceIndex, destinationIndex] > 0;
			}
			return false;
		}

		// Method to get the Indegree of a vertex (i.e., how many edges are connected to it (can reach it))
		public int GetInDegree(string vertex)
		{
			var degree = 0;// Initialize the degree count to zero
						   // Check if the vertex exists in the map
			if (_vertexDictionary.ContainsKey(vertex))
			{
				int vertexIndex = _vertexDictionary[vertex];
				// Loop through all possible connections (columns) for the given vertex (row)
				for (int i = 0; i < _numberOfVertices; i++)
				{
					if (_adjacencyMatrix[i, vertexIndex] > 0)
					{
						// If there's an edge (i.e., weight is greater than 0), increment the degree count
						degree++;
					}
				}
			}
			return degree;
		}

		// Method to get the Outdegree of a vertex (i.e., how many edges out of it and can go to)
		public int GetOutDegree(string vertex)
		{
			// Initialize the degree count to zero
			var degree = 0;
			// Loop through all possible connections (columns) for the given vertex (row)
			if (_vertexDictionary.ContainsKey(vertex))
			{
				int vertexIndex = _vertexDictionary[vertex];
				for (int i = 0; i < _numberOfVertices; i++)
				{
					// If there's an edge (i.e., weight is greater than 0), increment the degree count
					if (_adjacencyMatrix[vertexIndex, i] > 0)
					{
						degree++;
					}
				}
			}
			return degree;
		}
	}
}
