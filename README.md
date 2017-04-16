# KPU - the RISC based Open Source CPU
This repository contains complete source code and buillding files for the KPU - a RISC based CPU (Central Processing Unit). The whole CPU is emulated, simulated, and modelled on the lowest level only with primitive AND, OR, XOR, and NOT gates.

It implements a 8-bit wide Data Bus, and a 16-bit wide Address Bus. The following 8-bit wide registers are implemented:
<ul>
<li>D (General Purpose)</li>
<li>E (General Purpose)</li>
<li>F (General Purpose)</li>
<li>G (General Purpose)</li>
<li>H (General Purpose)</li>
<li>XL (Lower part of the 16-bit wide "X" register</li>
<li>XH (Upper part of the 16-bit wide "X" register</li>
</ul>

The following 16-bit wide registers are implemented:
<ul>
<li>SP (Stack Pointer)</li>
<li>BP (Base Pointer)</li>
<li>PC (Program Counter)</li>
<li>M (Memory Addressing)</li>
<li>J (Jump Destination Addressing)</li>
<li>X (General Purpose)</li>
<li>Y (General Purpose)</li>
<li>Z (General Purpose)</li>
</ul>

The project contains the following sub components:
<ul>
<li>Assembler: The Assembler generates from the assembly language binary code that can be executed by the CPU. It is written in C#, and uses ANTLR for the syntax processing.</li>
<li>Emulation: The C#-based Emulator is able to run binary code in a Console application or within a WinForms application (used for debugging purposes).</li>
<li>VHDL: This folder contains the whole CPU implementation as VHDL description files.</li>
<li>Eagle: This folder contains the whole schematics and board files ready for a physical implementation of the CPU based on 74LS TTL logic chips.</li>
<li>Logicly: This folder contains early Proof-Of-Concept files for the Logicly simulation program.</li>
<ul>
