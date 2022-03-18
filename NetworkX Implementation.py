import networkx as nx
import matplotlib.pyplot as plt

G = nx.DiGraph()

list_nodes = [0, 1, 2, 3, 4]
G.add_nodes_from(list_nodes)
print("Düğümler: ", G.nodes())

list_arcs = [(0, 1, 5.0), (0, 4, 2.0), (4, 3, 3.0), (2, 3, 2.0), (1, 2, 2.0),
             (2, 1, 1.0), (4, 2, 10.0), (1, 3, 6.0), (0, 2, 3.0), (4, 1, 6.0)]
G.add_weighted_edges_from(list_arcs)
print("Köşeler: ", G.edges)

nx.draw(G, with_labels=1)
plt.show()

# shortest_pathTo_0 = nx.dijkstra_path(G, source=4, target=0)
# shortest_pathTo_1 = nx.dijkstra_path(G, source=4, target=1)
# shortest_pathTo_2 = nx.dijkstra_path(G, source=4, target=2)
# shortest_pathTo_3 = nx.dijkstra_path(G, source=4, target=3)
# print(shortest_pathTo_0, shortest_pathTo_1, shortest_pathTo_2, shortest_pathTo_3)

G.remove_node(3)

nx.draw(G, with_labels=1)
plt.show()