# Path to your input and output files
input_file_path = 'dir.txt'  # Replace with the actual path to dir.txt
output_file_path = 'cleaned_dir.txt'

# Define the prefix to remove
prefix = "C:\\Users\\adam\\source\\repos"

# Process the file to remove the prefix and save the cleaned version
with open(input_file_path, 'r') as infile, open(output_file_path, 'w') as outfile:
    for line in infile:
        # Remove the prefix if it matches, else write as is
        if line.startswith(prefix):
            outfile.write(line[len(prefix):])
        else:
            outfile.write(line)

print(f"Cleaned file saved as {output_file_path}")