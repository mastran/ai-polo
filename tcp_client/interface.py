import tkinter as tk
import client

root = tk.Tk()
root.title("Hololens")
root.geometry("400x200")
frame = tk.Frame(root)
frame.pack()

# Add Buttons for Different commands/cues
# The co-ordinates are hard-coded because they need to be in reference with hololens that we are sending commands to.
# The commands include:
# . Show Eye/ Delete Eye
# . Show Fire/ Delete Fire
# . Show Fire2/ Delete Fire2
# . Show Fog/ Delete Fog
# . Show Beam/ Delete Beam
# . Show Butterfly/ Delete Butterfly

tk.Button(frame, text="Show Eye", width=12, command=lambda: client.send_command("ShowCube 0#0#3 0#0#0")). \
    grid(row=0, column=0)

tk.Button(frame, text="Delete Eye", width=12, command=lambda: client.send_command("DeleteCube 0#0#3 0#0#0")). \
    grid(row=0, column=1)

tk.Button(frame, text="Show Fire", width=12, command=lambda: client.send_command("ShowFire -0.7#-0.7#3 1#2#2")). \
    grid(row=1, column=0)

tk.Button(frame, text="Show Fire2", width=12, command=lambda: client.send_command("ShowFire 0.8#-0.7#3 1#2#2")). \
    grid(row=1, column=1)

tk.Button(frame, text="Delete Fire", width=12, command=lambda: client.send_command("DeleteFire 0.8#-0.8#3 1#2#2")). \
    grid(row=1, column=2)

tk.Button(frame, text="Show Fog", width=12, command=lambda: client.send_command("ShowFog 0#0#3 0#0#0")). \
    grid(row=2, column=0)

tk.Button(frame, text="Delete Fog", width=12, command=lambda: client.send_command("DeleteFog 0#0#0 0#0#0")). \
    grid(row=2, column=1)

tk.Button(frame, text="Show Beam", width=12, command=lambda: client.send_command("ShowBeam 0#0#3 0#0#0")). \
    grid(row=3, column=0)

tk.Button(frame, text="Delete Beam", width=12, command=lambda: client.send_command("DeleteBeam 0#0#3 0#0#0")). \
    grid(row=3, column=1)

tk.Button(frame, text="Show Fire", width=12, command=lambda: client.send_command("ShowFire 0#0#0 1#2#2")). \
    grid(row=4, column=0)

tk.Button(frame, text="Show Butterfly", width=12, command=lambda: client.send_command("ShowButterfly 1#1#3 0#0#0")). \
    grid(row=4, column=1)

tk.Button(frame, text="Delete Butterfly", width=12, command=lambda: client.send_command("DeleteButterfly 0#1#5 0#0#0")). \
    grid(row=4, column=2)

tk.Button(frame, text="QUIT", fg="red", command=quit).grid(row=5, column=0)

root.mainloop()
