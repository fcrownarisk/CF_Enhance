void Red(){
   int  element1[4][4] =
        {{1,0,0,0},
         {0,1,0,0},
         {0,0,1,0},
         {0,0,0,1}}
;
   int element2[4][4]=
        {{0,1,0,0},
         {0,0,1,0},
         {0,0,0,1},
         {1,0,0,0}}
;
   int element3[4][4]=
        {{0,0,0,1},
         {1,0,0,0},
         {0,1,0,0},
         {0,0,1,0}}
;
   int element4[4][4] =
        {{0,0,1,0},
         {0,0,0,1},
         {1,0,0,0},
         {0,1,0,0}}
;
}
void Green(){
     int element5[4][4] =
           {{1,0,1,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,0,0,1}}
;
     int element6[4][4] =
           {{1,0,0,0},
            {0,1,0,1},
            {0,0,1,0},
            {0,0,0,1}}
;
    int element7[4][4] =
           {{1,0,0,0},
            {0,1,0,0},
            {0,0,1,0},
            {0,1,0,1}}
;
    int element8[4][4] =
           {{1,0,0,0},
            {0,1,0,0},
            {1,0,1,0},
            {0,0,0,1}}
;
}
void Blue(){
 int element9[4][4] =
          {{0,1,0,1},
           {1,0,1,0},
           {0,0,0,1},
           {0,0,0,0}}
;
int element10[4][4] =
          {{0,1,0,1},
           {0,0,1,0},
           {0,1,0,1},
           {0,0,0,0}}
;
int element11[4][4] =
           {{0,1,0,1},
            {0,0,1,0},
            {0,0,0,1},
            {0,0,1,0}}
;
int element12[4][4] =
           {{0,1,0,1},
            {0,0,1,0},
            {0,0,0,1},
            {1,0,0,0}}
;
}
void anti(){
int element13[4][4] =
           {{1,0,1,0},
            {0,0,0,1},
            {1,0,0,0},
            {0,1,0,0}}
;
int element14[4][4] =
           {{0,0,1,0},
            {0,1,0,1},
            {1,0,0,0},
            {0,1,0,0}}
;
int element15[4][4] =
           {{0,0,1,0},
            {0,0,0,1},
            {1,0,1,0},
            {0,1,0,0}}
;
int element16[4][4] =
           {{0,0,1,0},
            {0,0,0,1},
            {1,0,0,0},
            {0,1,0,1}}
;
int element17[4][4] =
           {{0,1,0,0},
            {1,0,0,0},
            {0,1,0,0},
            {1,0,1,0}}
;
int element18[4][4] =
           {{0,0,0,0},
            {1,0,1,0},
            {0,1,0,0},
            {1,0,1,0}}
;
int element19[4][4] =
           {{0,0,0,0},
            {1,0,0,0},
            {0,1,0,1},
            {0,0,1,0}}
;
int element20[4][4] =
           {{0,0,0,1},
            {1,0,0,0},
            {0,1,0,0},
            {1,0,1,0}}
;
}
void CH4(double C, int H) {
    const C1 = C;
    const H4 = H * H + H * H;
}
void C5H12(double C, int H) {
   const C5 = C * C * 2 + C;
   const H12 = ( H * H + H * H ) * 3;
}
void C17H36(double C, int H) {
    const C17 = ( C * C ) * 4 + C;
    const H36 = ( H * H + H * H + H * H ) * 6;
}
void C2H4(float C, int H) {
    const C2 = C * C;
    const H4 = H * H + H * H;
}
void C6H8(float C, int H) {
    const C2 = C * C;
    const H6 = H * H + H * H + H * H;
}
void C14H16(float C, int H) {
    const C14 = ( C * C ) * 7;
    const H16 = ( H * H ) * 4;
}
void C2H2(int C, int H) {
   const C2 = C * C;
   const H2 = H * H;
}
void C4H2(int C, int H) {
   const C4 = C * C + C * C;
   const H2 = H * H ;
}
void C6H2(int C, int H){
   const C6 = ( C * C ) * 3;
   const H2 = H * H ;
}
void impact(){
 char impact0 = "element1 + element2 + element3 + element4";
 char impact1 = "element5 - element6 - element7 - element8";
 char impact2 = "element9 * element10 * element11 *element12";
 char impact3 = "element13 / element14 / element15 / element16";
 char impact4 = "element17 % element18 % element19 % element20";
 char impact5 = "impact0 * impact1 + impact2 * impact3";
 char impact6 = "impact1 - impact2 + impact3 - impact4";
 char impact7 = "impact0 / impact1 + impact3 / impact4";
 char impact8 = "impact1 % impact2 + impact3 % impact4";
}
void tetrahedron(radius,theta,fai){
    char X = radius * sin(theta) * cos(fai);
    char Y = radius * sin(theta) * sin(fai);
    char Z = radius * cos(fai);
    char T = radius * sin(theta);
    const SphereRadiusx = sin('z') + cos('y') + tan('x') + atan('t');
    const SphereRadiusy = sin('x') + cos('z') + tan('y') + atan('t');
    const SphereRadiusz = sin('y') + cos('x') + tan('z') + atan('t');
    const XYZTRed = (0,0,1); //A
    const XYZTGreen = (acos(-1/3),0,0); // B
    const XYZTBlue = (0, acos(-1/3),0); // C
    const XYZTanti = (0,0,acos(-1/3)); // D

}