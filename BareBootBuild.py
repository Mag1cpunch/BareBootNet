import os
import sys
import subprocess

Includes = ["ConsoleOS"]
CIncludes = [] # "LibC", "NativeLib" for now this is not used

def findFiles(path, extension):
    """Recursively finds all files with the given extension in the path."""
    fileList = []
    for root, dirs, files in os.walk(path):
        for file in files:
            if file.endswith(extension):
                fileList.append(os.path.join(root, file))
    return fileList

def main(workPath):
    response_file = "build.rsp"
    obj_dir = "./bin/Debug/net7.0/obj"
    output_bin = "./bin/Debug/net7.0/kernel.efi"

    os.makedirs(obj_dir, exist_ok=True)

    # Find all .cs files and write them to a response file
    with open(response_file, "w") as f:
        for include in Includes:
            includePath = os.path.join(workPath, include)
            files = findFiles(includePath, ".cs")
            for file in files:
                f.write(f'"{file}"\n')

    object_files = []
    for include in CIncludes:
        includePath = os.path.join(workPath, include)
        c_files = findFiles(includePath, ".c")
        for c_file in c_files:
            obj_file = os.path.join(obj_dir, os.path.basename(c_file).replace(".c", ".o"))
            object_files.append(obj_file)
            gcc_command = f"gcc -ffreestanding -fno-builtin -nostdlib -c \"{c_file}\" -o \"{obj_file}\""
            print(f"Compiling: {gcc_command}")
            os.system(gcc_command)

    if object_files:
        object_files_str = " ".join([f'-i "{obj}"' for obj in object_files])
    else:
        object_files_str = ""

    bflat_command = f'bflat build --arch x64 --os uefi --target Exe --stdlib Zero --libc none -o "{output_bin}" {object_files_str} @"{response_file}"'

    print(f"Running bflat: {bflat_command}")
    os.system(bflat_command)
    os.system("buildiso.bat")

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python BareBootBuild.py <work directory>")
        sys.exit(1)
    main(sys.argv[1])
