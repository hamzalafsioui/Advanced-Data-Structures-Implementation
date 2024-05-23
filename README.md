# Custom Collection Implementations in C#
This repository contains custom implementations of various collection interfaces in C#. These implementations demonstrate how to create collections that adhere to the standard IEnumerable, ICollection, IList, and IDictionary interfaces. The examples include both array-based and list-based approaches to illustrate different internal data structures.

## Overview:
## 1-IEnumerable
### Features
* **IEnumerable<T> Implementation:** Allows the collection to be iterated using foreach loops.
* **Custom Enumerator:** Utilizes the yield return statement to implement a custom enumerator.
* **Easy Addition of Elements:** Provides an Add method to add elements to the collection.


### Key Points
* **yield return:** The yield return statement is used within the GetEnumerator method to return elements one by one. It pauses the execution of the method and retains its state, allowing it to resume from the same point when the next element is requested.

* **IEnumerator<T>:** The GetEnumerator method returns an IEnumerator<T>, which provides the infrastructure for iterating over the collection.

## 2-ICollection
### SimpleCollection
A simple collection implementation using a List<T> as the underlying data structure. This collection provides basic functionality such as adding, removing, clearing, and checking for item existence.

### MyArrCollection
An implementation of ICollection<T> using an array (T[]) as the storage mechanism. This collection demonstrates custom array-based operations such as adding, removing, checking for item existence, and copying elements to another array.

### Features
* **Generic:** Both collections are generic and can store elements of any type (T).
* **Efficient Operations:** Each collection provides efficient implementations of common collection operations.
* **Iterability:** Implements IEnumerable<T> to allow iteration over collection elements using foreach loops.
* **Dynamic Resizing:** SimpleCollection automatically resizes its internal list, while MyArrCollection uses a fixed-size array.
* **Error Handling:** Includes appropriate error handling for operations such as adding to a full collection or removing non-existent items.

## 3-IList
### SimpleList
A custom list implementation using List<T> as the underlying data structure. This collection provides functionalities such as adding, removing, inserting, and updating elements, leveraging the built-in capabilities of List<T>.

### SimpleArray
An implementation of IList<T> using a fixed-size array (T[]) as the storage mechanism. This collection demonstrates custom array-based operations with dynamic resizing, providing similar functionalities to a list but with array-backed storage.

### Features
* **Generic:** Both collections are generic and can store elements of any type (T).
Efficient Operations:** Each collection provides efficient implementations of common list operations.
* **Iterability:** Implements IEnumerable<T> to allow iteration over collection elements using foreach loops.
* **Error Handling:** Includes appropriate error handling for operations such as accessing out-of-range elements or adding to a full collection.

## 4-IDictionary
### SimpleDictionary
A custom dictionary implementation using a List<KeyValuePair<TKey, TValue>> as the underlying data structure. This collection provides functionalities such as adding, removing, updating, and retrieving elements, leveraging the list's capabilities to store key-value pairs.

### SimpleArrDictionary
An implementation of IDictionary<TKey, TValue> using an array (KeyValuePair<TKey, TValue>[]) as the storage mechanism. This collection demonstrates custom array-based operations with dynamic resizing, providing dictionary-like functionalities with array-backed storage.

### Features
* **Generic:** Both collections are generic and can store elements of any type (TKey, TValue).
* **Efficient Operations:** Each collection provides efficient implementations of common dictionary operations.
* **Iterability:** Implements IEnumerable<KeyValuePair<TKey, TValue>> to allow iteration over collection elements using foreach loops.
* **Error Handling:** Includes appropriate error handling for operations such as accessing non-existent keys or adding duplicate keys.

## 5-ISet
**MyCollectionSet<T>** is a custom implementation of the ISet<T> interface, providing a collection of unique elements with various set operations. This class is designed to mimic the behavior of a set, ensuring that all elements are unique and supporting typical set operations like union, intersection, and difference.

### Features
* **Generic:** Can store elements of any type (T).
* **Unique Elements:** Ensures that all elements in the collection are unique.
* **Set Operations:** Supports union, intersection, difference, symmetric difference, and subset/superset checks.
* **Efficient Operations:** Provides efficient implementations of common set operations.
* **Iterability:** Implements IEnumerable<T> to allow iteration over set elements using foreach loops.
* **Error Handling:** Includes appropriate error handling for operations such as adding duplicates or removing non-existent elements.


