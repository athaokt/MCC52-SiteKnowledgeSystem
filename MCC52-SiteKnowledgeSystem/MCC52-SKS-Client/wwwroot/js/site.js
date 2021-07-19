   $.ajax({  
       url: "/Account/getregistrasiview", 
       success: function (result) {  
           console.log(result);  
    }  
   })
let dateObj = new Date();
let month = dateObj.getUTCMonth() + 1; //months from 1-12
let day = dateObj.getUTCDate();
let year = dateObj.getUTCFullYear();

newdate = year + "-" + month + "-" + day;
document.getElementById('date').innerHTML = newdate;