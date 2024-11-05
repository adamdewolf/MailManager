import json
import re

# Initialize the JSON structure
structure = {}

def insert_into_structure(path_parts, structure):
    """Recursively insert files and directories based on parts of the path."""
    if len(path_parts) == 1:
        # Base case: add file to current level
        structure.setdefault('files', []).append(path_parts[0])
    else:
        # Recursive case: move deeper into the structure
        folder = path_parts[0]
        structure.setdefault(folder, {})
        insert_into_structure(path_parts[1:], structure[folder])

# Define the file paths
tree_file_path = 'tree.txt'  # Update with your actual path
output_path = 'optimized_tree_structure.json'

# Read and parse each line from the file
with open(tree_file_path, 'r') as file:
    for line in file:
        # Strip special characters for formatting levels
        clean_line = re.sub(r'[¦+---]+', '', line).strip()
        if clean_line:
            # Split by '\' for directory structure, ensure consistent nesting
            path_parts = clean_line.split('\\')
            insert_into_structure(path_parts, structure)

# Save the structured JSON file
with open(output_path, 'w') as json_file:
    json.dump(structure, json_file, indent=2)

print(f"JSON structure saved to {output_path}")
