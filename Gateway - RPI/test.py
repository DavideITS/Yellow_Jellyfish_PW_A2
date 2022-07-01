from tkinter import Tk,Canvas,Frame,Label,StringVar,Button,Toplevel,Spinbox,BOTH,NONE,Checkbutton
from tkinter.messagebox import showerror
from PIL import ImageTk,Image
from tkinter.font import Font
from datetime import datetime
from os.path import join
from os import getcwd,system
import os
import json
from datetime import datetime, timedelta, date
import io
import platform
from threading import Thread
import time
from tkcalendar import Calendar
import sys

S_HEIGHT = 480
S_WIDTH = 800
SPLASH_TIME = 1000
def insertbutton(root,image,bkgcolor,height,width,x,y,command=None):
    btn = Button(
        master=root,
        height = height,
        width = width,
        bd = 0,
        relief = "flat",
        image = image,
        bg = bkgcolor,
        activebackground=bkgcolor,
        highlightthickness = 0,
        command = command
    )
    image.img = image
    btn.place(x=x,y=y)
    
def loadconfigFile(path:str):
    with open(path,"r") as file:
        return json.loads(file.read())
    

class SplashScreen(Frame):
    def __init__(self, master=None, x=0, y=0):
        super().__init__(
            master=master, 
            bg = "#181a1b",
            height = S_HEIGHT,
            width = S_WIDTH
        )
        self.root = master
        self.machlogo = Label(
            master=self,
            bg = "#181a1b",
            fg = "#FFFFFF",
            font = ("Titillium Web",55),
            width = 10,
            text = "treno",
            justify = "center",
            anchor = "center"
        )
        self.machlogo.place(x=190, y=175)
        self.place(x=x,y=y)
        self.after(SPLASH_TIME,self.showlockscreen)

    def showlockscreen(self):
        self.destroy()
        Home(self.root)
        
class Home(Frame):   
    def __init__(self, master=None, phasecode = 0):
        global numt  
        super().__init__(
            master=master, 
            height = S_HEIGHT,
            width = S_WIDTH,
            bg = "#2D3A71"
        )
        self.phasecode = phasecode
        self.root = master
        
## UPPER BAR ##
        self.upperbar = Frame(
            master=self,
            bg = "#050505",
            height = 70,
            width = S_WIDTH
        )
        self.pgmtitle = Label(
            master=self,
            bg = "#050505",
            fg = "#FFFFFF",
            font = ("Titillium Web",17,"bold"),
            text = "INFORMAZIONI",
            justify = "center",
            anchor = "center"
        )
        self.pgmtitle.place(x=(S_WIDTH - (20*12))/2, y=10)
    
        self.upperbar.place(x = 0, y = 0)
        
        
        
 ## PGM PARAMS ##

        self.pgmarea = Frame(
            master=self, 
            bg="#212121",
            height = 390,
            width = S_WIDTH
        )
        
        
        self.vagone1 = ImageTk.PhotoImage(
                Image.open(join(getcwd(),"Gateway - RPI","content","1x","Tavola disegno 1.png"))
            )
        insertbutton(self.pgmarea,self.vagone1,"#212121",100,100,0,0,self.detailsV1)
        
        self.vagone2 = ImageTk.PhotoImage(
                Image.open(join(getcwd(),"Gateway - RPI","content","1x","Tavola disegno 1.png"))
            )
        insertbutton(self.pgmarea,self.vagone2,"#212121",100,100,110,0,self.detailsV2)
        
        self.vagone3 = ImageTk.PhotoImage(
                Image.open(join(getcwd(),"Gateway - RPI","content","1x","Tavola disegno 1.png"))
            )
        insertbutton(self.pgmarea,self.vagone3,"#212121",100,100,220,0,self.detailsV3)
        
        self.vagone4 = ImageTk.PhotoImage(
                Image.open(join(getcwd(),"Gateway - RPI","content","1x","Tavola disegno 1.png"))
            )
        insertbutton(self.pgmarea,self.vagone4,"#212121",100,100,330,0,self.detailsV4)
        

    
     
        
        self.pgmarea.place(x = 0, y = 70)
        
## LOWER BAR ##

        self.lowerbar = Frame(
            master=self,
            bg = "#050505",
            height = 70,
            width = S_WIDTH
        )
        
       
        self.lowerbar.place(x = 0, y = 410)
        self.place(x = 0, y = 0)
        
    
    def detailsV1(self):
        self.root.children.clear()
        Details(self.root,1)
    def detailsV2(self):
        self.root.children.clear()
        Details(self.root,2)
    def detailsV3(self):
        self.root.children.clear()
        Details(self.root,3)
    def detailsV4(self):
        self.root.children.clear()
        Details(self.root,4)
  
  
  
    
class Details(Frame):   
    def __init__(self, master=None, phasecode = 0):
        super().__init__(
            master=master, 
            height = S_HEIGHT,
            width = S_WIDTH,
            bg = "#2D3A71"
        )
        self.phasecode = phasecode
        self.root = master
        print(self.phasecode)
        
    
## UPPER BAR ##
        self.upperbar = Frame(
            master=self,
            bg = "#050505",
            height = 70,
            width = S_WIDTH
        )
        self.pgmtitle = Label(
            master=self,
            bg = "#050505",
            fg = "#FFFFFF",
            font = ("Titillium Web",17,"bold"),
            text = "INFORMAZIONI",
            justify = "center",
            anchor = "center"
        )
        self.pgmtitle.place(x=(S_WIDTH - (20*12))/2, y=10)
        
        self.backimg = ImageTk.PhotoImage(
            Image.open(join(getcwd(),"Gateway - RPI","content","backbtn.png"))
        )
        insertbutton(self.upperbar,self.backimg,"#2D3A71",70,70,0,0,self.goback)       
        
        self.upperbar.place(x = 0, y = 0)
        
        
        
 ## PGM PARAMS ##

        self.pgmarea = Frame(
            master=self, 
            bg="#212121",
            height = 390,
            width = S_WIDTH
        )
        self.pgmarea.place(x = 0, y = 70)
        
        self.tabella = Label(
            master=self,
            bg = "#212121",
            fg = "#FFFFFF",
            font = ("Titillium Web",12,"bold"), 
            width = 25,
            height = 10,
            justify = "left",
            anchor = "w",
            text = "n vagone:"+"\n"+"Temperatura:"+"\n"+"Umidità:"+"\n"+"fumo:"+"\n"+"porta 1:"+"\n"+"porta 2:"+"\n"+"porta 3:"+"\n"+"porta 4:"+"\n"+"last data received:",
        )
        self.tabella.place(x=5, y=75)
     
        self.dati = Label(
            master=self,
            bg = "#212121",
            fg = "#FFFFFF",
            font = ("Titillium Web",12,"bold"), 
            width = 8,
            height = 10,
            justify = "left",
            anchor = "center"
        )
        self.dati.place(x=270, y=75)
        
        
## LOWER BAR ##

        self.lowerbar = Frame(
            master=self,
            bg = "#050505",
            height = 70,
            width = S_WIDTH
        )
        self.lowerbar.place(x = 0, y = 410)
        self.place(x = 0, y = 0)
        
        self.place(x = 0, y = 0)
        
        self.refresh()
    
    def goback(self):
        Home(self.root)
    
    def refresh(self):
        DataRT:dict = loadconfigFile(join(getcwd(),"Gateway - RPI","content","RealTime","data.json"))

        p01 = DataRT["vagone"][0]["nrTrain"]
        print(p01)
        self.dati.configure(
                text = str(DataRT["vagone"][0]["nrTrain"])+"\n"+
                       str(DataRT["vagone"][0]["nrWagon"])+"\n"+
                       str(DataRT["vagone"][0]["Temp"])+"\n"+
                       str(DataRT["vagone"][0]["hum"])+"\n"+
                       str(DataRT["vagone"][0]["smoke"])+"\n"+
                       str(DataRT["vagone"][0]["Toilet"])+"\n"+
                       str(DataRT["vagone"][0]["port"])
        )
                       
        self.dati.after(1000, self.refresh)   



def main():
    root = Tk()
    #root.overrideredirect(1)
    root.geometry("%dx%d+%d+%d"%(S_WIDTH, S_HEIGHT, (root.winfo_screenwidth()/2)-400, (root.winfo_screenheight()/2)-240))
    SplashScreen(root,0,0)
    #root.config(cursor='none')
    #root.after(CYC_INFO_REFRESH,cycleinfo,root)
    #root.after(SYS_ALM_CHECK,alarmsmanagement,root)
    #root.after(REBOOT_REQ_DELAY,rebootrequest,root)
    while 1:
        root.update()
        
if __name__ == "__main__":
    gui = Thread(name = "cpcontrolgui",target=main,daemon=False)
   
    gui.start()