# ImageToPainting

README:

This projects is a System or Tool that loads an image from the internet, applies a custom Oil Paint Shader, allows the user to adjust the desired amount of paint strokes, then saves the image to the Desktop.

How does it work?

An image is pulled from the web using UnityWebRequest. It is then applied as a texture to an instance of a material with a custom Oil Painting filter shader with the amount of paint strokes set to 0. The shader gets the value of the slider as it is moved, increasing or decreasing the amount of paint strokes applied to the image. A screen shot from a render texture created of the new filtered imaged can then be taken and saved to the users Desktop. Current saved images will be saved over if not moved to a new folder. The user may also reset the image and take another.


Convert an Image from the Web into a painting.

Type or paste a URL for an image in the Input Field.

Test image URL: https://images.hdqwalls.com/download/united-arab-emirates-to-2048x2048.jpg

Click LOAD IMAGE.

Use the Slider to adjust the number of paint strokes.

When you are happy with your masterpiece, click SAVE IMAGE and it will be saved to your Desktop as a 2048 x 2048 png image with the name CameraScreenShot.png

*IF NO IMAGE IS LOADED THEN A BLANK IMAGE WILL BE SAVED


Enter Image URL - This URL will be used to load your image from the web (ex: http://www.mysite.com/image.jpg)

LOAD IMAGE - Loads URL entered into input field. Must be an image (png, jpg, gif).

SAVE IMAGE - Saves the image on the screen to the Desktop as a 2048 x 2048 png image with the name CameraScreenShot.png. Your current image will be saved over, so move any images you want to save to a new folder.

RESET IMAGE - Resets the URL input field and removes the current loaded texture.

QUIT - Quits application.

Slider - Controls the number of Paint Strokes added to image. The more the slider is moved to the right, the more your image will look like a painting.


OilPaint Shader

The OildPaint Shader in the Shader folder uses the Kawahara algorithm to blur the indvidual pixels of the image creating a painted look.

It is normally used as a screen space effect, but this has been converted to be used an Unlit Shader for meshes.
