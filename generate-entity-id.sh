#!/bin/bash

show_usage() {
    echo "Usage: $0 -p <path> -c <class1,class2,...>"
    echo
    echo "Parameters:"
    echo "  -p    Full path where files should be generated"
    echo "        Must start with './src/'"
    echo "        Example: ./src/Domain/StockAggregate/ValueObjects/Ids"
    echo
    echo "  -c    Comma-separated list of class names (without Id suffix)"
    echo "        Example: \"StockOrder,Product\""
    echo
    echo "Example:"
    echo "  $0 -p \"./src/Domain/StockAggregate/ValueObjects/Ids\" -c \"StockOrder\""
    exit 1
}

# Parse command line arguments
while getopts "p:c:" opt; do
    case $opt in
        p) PATH_TO_USE="$OPTARG";;
        c) CLASSES="$OPTARG";;
        ?) show_usage;;
    esac
done

# Check if required parameters are provided
if [ -z "$PATH_TO_USE" ] || [ -z "$CLASSES" ]; then
    show_usage
fi

# Validate path starts with ./src/
if [[ ! "$PATH_TO_USE" =~ ^\.\/src\/ ]]; then
    echo "Error: Path must start with './src/'"
    exit 1
fi

# Extract namespace from path
# Remove ./src/ prefix and convert / to .
NAMESPACE=$(echo "$PATH_TO_USE" | sed 's/^\.\/src\///' | sed 's/\//./g')

# Function to generate ID class content
generate_id_class() {
    local CLASS_NAME="$1"
    local YEAR=$(date +%Y)
    
    cat << EOF
// Copyright (c) $YEAR Jonathan Sillak. All rights reserved.
// Licensed under the MIT license.

namespace $NAMESPACE;

using System;
using CocktailBar.Domain.Common;

public sealed class ${CLASS_NAME}Id : BaseId<${CLASS_NAME}Id>, IBaseId<${CLASS_NAME}Id>
{
    private ${CLASS_NAME}Id(Guid value) : base(value) { }

    public static ${CLASS_NAME}Id New() => new ${CLASS_NAME}Id(Guid.NewGuid());

    public static ${CLASS_NAME}Id From(Guid id) => new ${CLASS_NAME}Id(id);
}
EOF
}

# Create directory if it doesn't exist
if ! mkdir -p "$PATH_TO_USE" 2>/dev/null; then
    echo "Error: Could not create directory: $PATH_TO_USE"
    exit 1
fi

# Process each class
IFS=',' read -ra CLASS_ARRAY <<< "$CLASSES"
for CLASS in "${CLASS_ARRAY[@]}"; do
    # Remove any whitespace
    CLASS=$(echo "$CLASS" | xargs)
    
    # Generate file
    FILE_PATH="$PATH_TO_USE/${CLASS}Id.cs"
    if ! generate_id_class "$CLASS" > "$FILE_PATH" 2>/dev/null; then
        echo "Error: Could not generate file: $FILE_PATH"
        exit 1
    fi
    
    echo "Generated $FILE_PATH"
done
