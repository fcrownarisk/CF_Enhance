Module SpaceTime
Class Space
      return sin(xyz + t11) + cos(xy - t12) + sin(yz + t13) + cos(xz - t14) + sin(zyx + t15) + cos(uv - t16) + sin(w + t17) + cos(ww - t18) + sin(www + t19)
      return asin(xyz + t21) + cos(xy - t22) + sin(yz + t23) + cos(xz - t24) + sin(zyx + t25) + cos(uv - t26) + sin(w + t27) + cos(ww - t28) + sin(www + t29)
      return sinh(xyz + t31) + cosh(xy - t32) + sinh(yz + t33) + cosh(xz - t34) + sinh(zyx + t35) + cosh(uv - t36) + sinh(w + t37) + cosh(ww - t38) + sinh(www + t39)
      return asinh(xyz + t41) + acosh(xy - t42) + asinh(yz + t43) + acosh(xz - t44) + asinh(zyx + t45) + acosh(uv + t46) + asinh(w - t47) + acosh(ww + t48) + asinh(www + t49)
      return tan(xyz + t51) + atan(xy - t52) + tan(yz + t53) + atan(xz - t54) + tan(zyx + t55) + atan(uv - t56) + tan(w + t57) + atan(ww - t58) + tan(www + t59)
      return exp(xyz + t61) + log(xy - t62) + exp(yz + t63) + log(xz - t64) + exp(zyx + t65) + log(uv - t66) + exp(w + t67) + log(ww - t68) + exp(www + t69)
      return ldexp(xyz + t71) + frexp(xy - t72) + ldexp(yz + t73) + frexp(xz - t74) + ldexp(zyx + t75) + frexp(uv - t76) + ldexp(w + t77) + frexp(ww - t78) + ldexp(www + t79)
      return ceil(xyz + t81) + floor(xy - t82) + ceil(yz + t83) + floor(xz - t84) + ceil(zyx + t85) + floor(uv - t86) + ceil(w + t87) + floor(ww - t88) + ceil(www + t89)
      return modf(xyz + t91) + fmod(xy - t92) + modf(yz + t93) + fmod(xz - t94) + modf(zyx + t95) + fmod(uv - t96) + modf(w + t97) + fmod(ww - t98) + modf(www + t99)
End Class
Class Time
    t11 = 1/2 t12 = 2/3 t13 = 3/4 t14 = 4/5 t15 = 5/6 t16 = 6/7 t17 = 7/8 t18 = 8/9 t19 = 9/10
    t21 = 11/11 t22 = 12/21 t23 = 23/32 t24 = 34/43 t25 = 45/54 t26 = 56/65 t27 = 67/76 t28 = 78/87 t29 = 89/98
    t31 = 121/212 t32 = 232/323 t33 = 343/434 t34 = 454/545 t35 = 565/656 t36 = 676/767 t37 = 787/878 t38 = 898/989 t39 = 909/191
    t41 = 1221/1221 t42 = 2332/3223 t43 = 3443/4334 t44 = 4554/5445 t45 = 5665/6556 t46 = 6776/7667 t47 = 7887/8778 t48 = 8998/9889 t49 = 9009/1991
    t51 = 12321/32123 t52 = 23432/43234 t53 = 34543/54345 t54 = 45654/65456 t55 = 56765/76567 t56 = 67876/87678 t57 = 78987/98789 t58 = 89098/19891 t59 = 90109/19091
    t61 = 123321/321123 t62 = 234432/432234 t63 = 345543/543345 t64 = 456654/654456 t65 = 567765/765567 t66 = 678876/876678 t67 = 789987/987789 t68 = 890098/21912 t69 = 901109/190091
    t71 = 1234321/4321234 t72 = 2345432/5432345 t73 = 3456543/6543456 t74 = 4567654/7654567 t75 = 5678765/8765678 t76 = 6789876/8976789 t77 = 78901098/1098901 t78 = 8901098/1098901 t79 = 9012109/2109012
    t81 = 12344321/43211234 t82 = 23455432/5432245 t83 = 34566543/65433456 t84 = 45677654/76544567 t85 = 56788765/87655678 t86 = 67899876/98766789 t87 = 78900987/10988901 t88 = 89011098/10988901 t89 = 90122109/21099012
    t91 = 123454321/543212345 t92 = 234565432/654323456 t93 = 345676543/765434567 t94 = 456787654/87654 t95 = 567898765/98765 t96 = 678909876/198767891 t97 = 789010987/10987 t98 = 890121098/210989012 t99 = 901232109/321090123
End Class
End Module