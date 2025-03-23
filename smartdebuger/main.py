import tkinter as tk
from tkinter import messagebox, scrolledtext
import subprocess
import requests
import json
import os
import tempfile

# Global variable for API key
api_key = os.getenv("MISTRAL_API_KEY", "")

# Definiši tačnu putanju do GDB-a ako treba
GDB_PATH = "C:/msys64/mingw64/bin/gdb.exe"  # Proveri i prilagodi putanju

def run_gdb():
    code = code_text.get("1.0", tk.END).strip()
    if not code:
        messagebox.showwarning("Warning", "Please enter the buggy code before running!")
        return

    try:
        # Kreiraj privremeni Python fajl sa kodom
        with tempfile.NamedTemporaryFile(delete=False, suffix=".py") as tmp_file:
            tmp_file.write(code.encode())
            tmp_filename = tmp_file.name.replace("\\", "/")  # MSYS2 koristi Unix-style putanje

        # Kreiraj privremeni GDB skript fajl
        with tempfile.NamedTemporaryFile(delete=False, suffix=".gdb") as gdb_file:
            gdb_script_filename = gdb_file.name.replace("\\", "/")  # Unix-style putanja
            gdb_script = f"""
            set pagination off
            file python.exe
            run {tmp_filename}
            bt
            quit
            """
            gdb_file.write(gdb_script.encode())

        # Pokreni GDB sa skriptom iz fajla
        result = subprocess.run(
            [GDB_PATH, "--batch", "-x", gdb_script_filename],
            capture_output=True, text=True
        )

        # Prikaz izlaza u Tkinter Text vidžetu
        output_text.delete("1.0", tk.END)
        output_text.insert(tk.END, result.stdout + result.stderr)

        # Obriši privremene fajlove
        os.unlink(tmp_filename)
        os.unlink(gdb_script_filename)

        return result.stdout + result.stderr

    except FileNotFoundError:
        messagebox.showerror("Error", "GDB is not installed or path is incorrect.")
    except Exception as e:
        messagebox.showerror("Error", f"An error occurred: {str(e)}")

    return None

# Function to send GDB output (patch) to Mistral AI API for commenting
def send_to_mistral():
    global api_key
    gdb_output = output_text.get("1.0", tk.END).strip()
    
    if not gdb_output:
        messagebox.showwarning("Warning", "No GDB output to send!")
        return
    
    if not api_key:
        messagebox.showwarning("Warning", "Please enter the API key before sending!")
        return

    url = "https://api.mistral.ai/v1/chat/completions"
    headers = {
        "Authorization": f"Bearer {api_key}",
        "Content-Type": "application/json"
    }
    
    data = {
        "model": "mistral-small",
        "messages": [{"role": "user", "content": f"Prokomentariši sledeći GDB output (ispravku) na srpskom jeziku na latinici:\n{gdb_output}"}],
        "temperature": 0.7
    }
    
    try:
        response = requests.post(url, headers=headers, json=data)
        response.raise_for_status()  # Raise an error for bad status codes
        response_data = response.json()
        explanation = response_data.get("choices", [{}])[0].get("message", {}).get("content", "No response.")

        # Append the Mistral AI comment to the output text area
        output_text.insert(tk.END, "\n\n--- Mistral AI Comment ---\n")
        output_text.insert(tk.END, explanation)

    except requests.exceptions.RequestException as e:
        messagebox.showerror("Error", f"An error occurred while sending the API request: {str(e)}")

# Functions for API key management
def save_api_key():
    global api_key
    api_key = api_key_entry.get()
    messagebox.showinfo("Info", "API key saved!")

def reset_api_key():
    global api_key
    api_key = ""  # Reset the API key
    api_key_entry.delete(0, tk.END)
    messagebox.showinfo("Info", "API key reset!")

# Create the main Tkinter window
root = tk.Tk()
root.title("Smart Debugger")

# API key input
tk.Label(root, text="Mistral AI API Key:").pack()
api_key_entry = tk.Entry(root, width=50)
api_key_entry.pack()
tk.Button(root, text="Save Key", command=save_api_key).pack()
tk.Button(root, text="Reset Key", command=reset_api_key).pack()

# Code input area
code_text = scrolledtext.ScrolledText(root, width=60, height=10)
code_text.pack()

# Button to run GDB
tk.Button(root, text="Run GDB", command=run_gdb).pack()

# Output area
output_text = scrolledtext.ScrolledText(root, width=60, height=10)
output_text.pack()

# Button to send GDB output to Mistral AI API
tk.Button(root, text="Send to Mistral AI API", command=send_to_mistral).pack()

# Start the Tkinter event loop
root.mainloop()