function x = Shift(pow, x, h, f)
        x = f(x + pow*h);
end