# KPU - the RISC based Open Source CPU
This repository contains complete source code and buillding files for the KPU - a RISC based CPU (Central Processing Unit). The whole CPU is emulated, simulated, and modelled on the lowest level only with primitive AND, OR, XOR, and NOT gates.

It implements a 8-bit wide Data Bus, and a 16-bit wide Address Bus. The following 8-bit wide registers are implemented:
<ul>
<li><b>D</b> (General Purpose)</li>
<li><b>E</b> (General Purpose)</li>
<li><b>F</b> (General Purpose)</li>
<li><b>G</b> (General Purpose)</li>
<li><b>H</b> (General Purpose)</li>
<li><b>XL</b> (Lower part of the 16-bit wide "X" register</li>
<li><b>XH</b> (Upper part of the 16-bit wide "X" register</li>
</ul>

The following 16-bit wide registers are implemented:
<ul>
<li><b>SP</b> (Stack Pointer)</li>
<li><b>BP</b> (Base Pointer)</li>
<li><b>PC</b> (Program Counter)</li>
<li><b>M</b> (Memory Addressing)</li>
<li><b>J</b> (Jump Destination Addressing)</li>
<li><b>X</b> (General Purpose)</li>
<li><b>Y</b> (General Purpose)</li>
<li><b>Z</b> (General Purpose)</li>
</ul>

The project contains the following sub components:
<ul>
<li><b>Assembler</b>: The Assembler generates from the assembly language binary code that can be executed by the CPU. It is written in C#, and uses ANTLR for the syntax processing.</li>
<li><b>Emulation</b>: The C#-based Emulator is able to run binary code in a Console application or within a WinForms application (used for debugging purposes).</li>
<li><b>VHDL</b>: This folder contains the whole CPU implementation as VHDL description files.</li>
<li><b>Eagle</b>: This folder contains the whole schematics and board files ready for a physical implementation of the CPU based on 74LS TTL logic chips.</li>
<li><b>Logicly</b>: This folder contains early Proof-Of-Concept files for the Logicly simulation program.</li>
</ul>

For more detailed technical information about the CPU, please visit the project website at http://www.cpu-design.at
