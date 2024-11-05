import json

# Define the input and output file paths
input_file_path = 'cleaned_dir.txt'  # Update with actual path to your cleaned file
output_file_path = 'optimized_cleaned_tree_structure.json'

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

# Read and parse each line from the file
with open(input_file_path, 'r') as file:
    for line in file:
        clean_line = line.strip()
        if clean_line:
            path_parts = clean_line.split('\\')
            insert_into_structure(path_parts, structure)

# Save the structured JSON file
with open(output_file_path, 'w') as json_file:
    json.dump(structure, json_file, indent=2)

print(f"JSON structure saved to {output_file_path}")
