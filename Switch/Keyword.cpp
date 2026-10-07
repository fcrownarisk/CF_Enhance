/* ============================================
   COMPLETE LIST OF C++ KEYWORDS (C++20)
   ============================================

   Traditional Keywords:
   alignas        alignof       and           and_eq       
   asm            auto          bitand        bitor        
   bool           break         case          catch        
   char           char8_t       char16_t      char32_t     
   class          compl         concept       const        
   consteval      constexpr     const_cast    continue     
   co_await       co_return     co_yield      decltype     
   default        delete        do            double       
   dynamic_cast   else          enum          explicit     
   export         extern        false         float        
   for            friend        goto          if           
   inline         int           long          mutable      
   namespace      new           noexcept      not          
   not_eq         nullptr       operator      or           
   or_eq          private       protected     public       
   register       reinterpret_cast require    return       
   short          signed        sizeof        static       
   static_assert  static_cast   struct        switch       
   template       this          thread_local  throw        
   true           try           typedef       typeid       
   typename       union         unsigned      using        
   virtual        void          volatile      wchar_t      
   while          xor           xor_eq

   C++20 Additions:
   char8_t        concept       consteval     co_await     
   co_return      co_yield      requires

   Alternative Tokens (digraphs/trigraphs):
   and     (&&)   bitand  (&)   bitor   (|)   compl   (~)
   not     (!)    not_eq  (!=)  or      (||)  or_eq   (|=)
   xor     (^)    xor_eq  (^=)

   Contextual Keywords (have special meaning in specific contexts):
   final          override      import        module       
   export

   ============================================
   Notes:
   - C++11 added: alignas, alignof, char16_t, char32_t, constexpr,
                  decltype, noexcept, nullptr, static_assert, thread_local
   - C++14 added: [[deprecated]]
   - C++17 added: [[maybe_unused]], [[nodiscard]], [[fallthrough]]
   - C++20 added: char8_t, concept, consteval, co_await, co_return,
                  co_yield, requires, import, module
   - Some keywords like 'requires' and 'concept' require C++20
   - 'export' for modules is different from traditional 'export'
   ============================================ */
1 alignas: Specifies the alignment requirement of a type or object
2 alignof: Queries the alignment requirement of a type
3 and: Alternative representation of the logical AND operator
4 and_eq: Alternative representation of the bitwise AND assignment operator
5 asm: Used to embed assembly code
6 auto: Used for type deduction; automatically deduces the type of a variable from its initializer
7 bitand: Alternative representation of the bitwise AND operator
8 bitor: Alternative representation of the bitwise OR operator
9 bool: Boolean type
10 break: Exits a loop or switch statement
11 case: A branch in a switch statement
12 catch: Exception handling; catches exceptions
13 char: Character type
14 char8_t: Type used to represent UTF-8 characters (introduced in C++20)
15 char16_t: Type used to represent UTF-16 characters
16 char32_t: Type used to represent UTF-32 characters
17 class: Declares a class
18 compl: Alternative representation of the bitwise NOT operator
19 const: Defines a constant, or specifies that a function does not modify the object
20 constexpr: Declares a constant expression, evaluated at compile time
21 const_cast: Used to modify the const or volatile qualification of a type
22 continue: Skips the remaining code in the current loop iteration and starts the next iteration
23 decltype: Queries the type of an expression
24 default: The default branch in a switch statement, or explicitly defaulting a special member function
25 delete: Frees dynamically allocated memory, or disables the use of a function
26 do: Loop statement that executes the loop body at least once
27 double: Double-precision floating-point type
28 dynamic_cast: Performs safe downcasting within an inheritance hierarchy
29 else: The alternative branch of an if statement
30 enum: Declares an enumeration type
31 explicit: Prohibits implicit conversion by a constructor or conversion function
32 export: Used for template declarations; now rarely used
33 extern: Declares a variable or function defined elsewhere
34 false: The false value of the Boolean type
35 float: Single-precision floating-point type
36 for: Loop statement
37 friend: Declares a friend function or class
38 goto: Unconditional jump statement
39 if: Conditional statement
40 inline: Suggests that the compiler expand a function inline
41 int: Integer type
42 long: Long integer type or long double-precision floating-point type
43 mutable: Allows a class member to be modified in a const member function
44 namespace: Declares a namespace
45 new: Dynamically allocates memory
46 not: Alternative representation of the logical NOT operator
47 not_eq: Alternative representation of the not-equal-to operator
48 nullptr: Null pointer constant
49 operator: Overloads an operator
50 or: Alternative representation of the logical OR operator
51 or_eq: Alternative representation of the bitwise OR assignment operator
52 private: Declares private access for class members
53 protected: Declares protected access for class members
54 public: Declares public access for class members
55 register: Suggests that the compiler store a variable in a register (deprecated in C++17)
56 reinterpret_cast: Used for low-level reinterpretation type conversions
57 return: Returns from a function
58 short: Short integer type
59 signed: Signed integer type
60 sizeof: Queries the size of a type or object
61 static: Static storage duration or internal linkage
62 static_assert: Compile-time assertion
63 static_cast: Used for non-polymorphic type conversions
64 struct: Declares a structure
65 switch: Multi-way selection statement
66 template: Declares a template
67 this: Pointer to the current object
68 throw: Throws an exception
69 true: The true value of the Boolean type
70 try: Exception handling; attempts to execute a block of code that may throw an exception
71 typedef: Defines a type alias
72 typeid: Queries type information
73 typename: Declares a type name in a template, or is used instead of class to declare template parameters
74 union: Declares a union
75 unsigned: Unsigned integer type
76 using: Introduces namespace members or defines a type alias
77 virtual: Declares a virtual function
78 void: No type
79 volatile: Specifies that an object may be modified unexpectedly, prohibiting optimization
80 wchar_t: Wide character type
81 while: Loop statement
82 xor: Alternative representation of the bitwise XOR operator
83 xor_eq: Alternative representation of the bitwise XOR assignment operator