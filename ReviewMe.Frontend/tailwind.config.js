const colors = require('tailwindcss/colors');

module.exports = {
    prefix: 'reviewme-',
    theme: {
        colors: {
            transparent: 'transparent',
            current: 'currentColor',
            gray: colors.trueGray,
            black: colors.black,
            white: colors.white,
            blue: {
                50: "#e6ebef",
                100: "#ced7df",
                200: "#9cb0bf",
                300: "#6b889e",
                400: "#39617e",
                500: "#08395e",
                600: "#062e4b",
                700: "#052238",
                800: "#031726",
                900: "#020b13"
            },
            red: {
                100: '#fcd5dd',
                200: '#f9abbc',
                300: '#f5809a',
                400: '#f25679',
                500: '#ef2c57',
                600: '#bf2346',
                700: '#8f1a34',
                800: '#601223',
                900: '#300911'
            },
            green: {
                400: 'hsl(134, 61%, 41%)'
            },
            yellow: {
                400: 'hsl(45, 100%, 52%)'
            },
            info: {
                DEFAULT: '#CDE5FE'
            }
        },
        boxShadow: {
            DEFAULT: '0 0 5px #888'
        },
        extend: {
            fontFamily: {
                sans: ["Roboto", "-apple-system", "BlinkMacSystemFont", "Segoe UI", "Helvetica Neue", "Arial", "Noto Sans", "Liberation Sans", "sans-serif", "Apple Color Emoji", "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji"]
            },
            maxWidth: {
                '95/100': '95%',
                '90/100': '90%'
            },
            width: {
                '1/7': '14.2857143%'
            },
            aspectRatio: {
                '4/3': '4 / 3',
            },
        }
    },
    content: [
        './**/*.html',
        './**/*.razor',
        '../ReviewMe.Components/**/*.html',
        '../ReviewMe.Components/**/*.razor'
    ],
    plugins: []
}