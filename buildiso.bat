mkdir "bin\Debug\net7.0\iso_root" 2>nul
mkdir "bin\Debug\net7.0\iso_root\EFI" 2>nul
mkdir "bin\Debug\net7.0\iso_root\limine" 2>nul
mkdir "bin\Debug\net7.0\iso_root\EFI\BOOT" 2>nul

copy /Y "bin\Debug\net7.0\kernel.efi" "bin\Debug\net7.0\iso_root\EFI\BOOT\kernel.efi"

copy /Y "bin\Debug\net7.0\limine\limine-bios.sys" "bin\Debug\net7.0\iso_root\limine"
copy /Y "bin\Debug\net7.0\limine\limine-bios-cd.bin" "bin\Debug\net7.0\iso_root\limine"
copy /Y "bin\Debug\net7.0\limine\limine-uefi-cd.bin" "bin\Debug\net7.0\iso_root\limine"

copy /Y "bin\Debug\net7.0\limine\BOOTX64.EFI" "bin\Debug\net7.0\iso_root\EFI\BOOT\BOOTX64.EFI"

xorriso -as mkisofs -b limine/limine-bios-cd.bin -no-emul-boot -boot-load-size 4 -boot-info-table -iso-level 3 -joliet -joliet-long -rational-rock -o "bin\Debug\net7.0\kernel.iso" "bin\Debug\net7.0\iso_root"

"bin\Debug\net7.0\limine\limine.exe" bios-install "bin\Debug\net7.0\kernel.iso"