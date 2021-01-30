from random import randint, random

from colour import Color
from PIL import Image


MIN_HEIGHT = 13
MAX_HEIGHT = 16

MIN_WIDTH = 3
MAX_WIDTH = 7

DEFAULT_SATURATION = 0.30
DEFAULT_LIGHTNESS = 0.28

PAGE_GREY = (151, 151, 151, 255)
PAGE_SHADOW = (100, 100, 100, 255)

def flatten(data):
    result = []
    for row in data:
        for c in row:
            result.append(c)

    return result


def color_to_rgba(color):
    return tuple([int(c * 255) for c in color.rgb]) + (255,)


def generate(filename):
    width = randint(MIN_WIDTH, MAX_WIDTH)
    height = randint(MIN_HEIGHT, MAX_HEIGHT)
    length = width * height

    h = random()
    s = DEFAULT_SATURATION
    ll = DEFAULT_LIGHTNESS

    main_color = Color(hsl=(h, s, ll))
    main_rgb = tuple([int(c * 255) for c in main_color.rgb])

    # Fill with color
    img_data = []
    for y in range(0, height):
        row = []
        for x in range(0, width):
            row.append(main_rgb + (255,))

        img_data.append(row)

    # Add shadows
    darkest = color_to_rgba(Color(hsl=(h, s, ll - 0.1)))
    lighter = color_to_rgba(Color(hsl=(h, s, ll - 0.07)))
    for y in range(4, height):
        img_data[y][0] = darkest
        img_data[y][1] = lighter

    # Carve out pages at the top
    for i in range(1, width - 1):
        img_data[0][i] = (0, 0, 0, 0)

    for y in range(1, 5):
        for x in range(1, width - 1):
            img_data[y][x] = PAGE_GREY

    for y in range(2, 5):
        img_data[y][width - 2] = PAGE_SHADOW

    # Remove bottom corners
    img_data[height - 1][0] = (0, 0, 0, 0)
    img_data[height - 1][width - 1] = (0, 0, 0, 0)

    # Save
    img = Image.new('RGBA', (width, height), 0)
    img.putdata(flatten(img_data))
    img.save('books_tmp/{}'.format(filename))



for i in range(10, 50):
    generate('book_{}.png'.format(i))
