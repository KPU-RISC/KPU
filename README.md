# KPU - the RISC based Open Source CPU
This repository contains complete source code and buillding files for the KPU - a RISC based CPU (Central Processing Unit). The project contains the following sub components:
<ul>
<li>Assembler: The Assembler generates from the assembly language binary code that can be executed by the CPU. It is written in C#, and uses ANTLR for the syntax processing.</li>
<li>Emulation: The C#-based Emulator is able to run binary code in a Console application or within a WinForms application (used for debugging purposes).</li>
<li>VHDL: This folder contains the whole CPU implementation as VHDL description files.</li>
<li>Eagle: This folder contains the whole schematics and board files for a physical implementation of the CPU</li>
<li>Logicly: This folder contains early Proof-Of-Concept files for the Logicly simulation program.</li>
<ul>
