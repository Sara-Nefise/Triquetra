const { Builder, By, Key } = require('selenium-webdriver');

(async function example() {
    const driver = await new Builder().forBrowser('firefox').build()
        // eslint-disable-next-line indent
        // Navigate to Url
    await driver.get("http://127.0.0.1:3000/")
    let AnaSayifa_URL = await driver.getCurrentUrl()

    // 2.Senaryo 
    let text = 'Amper1'
    await driver.findElement(By.xpath('/html/body/div/div/div/div/header/div/div[2]/div/div[1]/div')).click()
    await driver.findElement(By.id('search-input')).sendKeys(text, Key.ENTER)
    await driver.findElement(By.id('search-input')).sendKeys(Key.RETURN)
        // Get attribute of current active element
    let attr = await driver.switchTo().activeElement().getAttribute('value')
        //console.log(`${attr}`)
    if (attr == text) {
        console.log(`2.Senaryo Başarsiz`)
    } else {
        console.log(`2.Senaryo Başarili`)
    }

    //3.Senaryo
    let long_text = 'asdfghjklqwertyuio'
    await driver.findElement(By.id('search-input')).sendKeys(long_text, Key.ENTER)
    await driver.findElement(By.id('search-input')).sendKeys(Key.RETURN)
    attr = await driver.switchTo().activeElement().getAttribute("value")
    if (attr.length > 20) {
        console.log(`3.Senaryo Başarsiz`)
    } else {
        console.log(`3.Senaryo Başarili`)
    }
    //4.Senaryo 
    await driver.findElement(By.xpath('/html/body/div/div/div/div/header/div/div[3]')).click()
    let Url_sepet = await driver.getCurrentUrl()
    if (Url_sepet == 'http://127.0.0.1:3000/cart') {
        console.log(`4.Senaryo Başarili`)
    } else {
        console.log(`4.Senaryo Başarsiz`)
    }
    //5.Senaryo
    await driver.findElement(By.xpath('/html/body/div/div/div/div/nav/div[1]/div/a[2]')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/header/div/div[1]/a/span')).click()
    let url_1 = await driver.getCurrentUrl()
        //console.log(`${url_1}`)
    if (url_1 == AnaSayifa_URL) {
        console.log(`5.Senaryo Başarili`)
    } else {
        console.log(`5.Senaryo Başarsiz`)
    }
    //9.Senaryo
    await driver.findElement(By.xpath('/html/body/div/div/div/div/nav/div[1]/div/a[2]')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div/input')).sendKeys('123a', Key.ENTER)
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div/input')).sendKeys(Key.RETURN)
    let attr_1 = await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[2]/div/div/div/div/div/input')).getAttribute("value")
        //console.log(`${attr_1}`)

    if (!/[^a-zA-Z]/.test(attr_1)) {
        //sayi olmadigi icin Başarsiz
        console.log(`9.Senaryo Başarsiz`)
    } else {
        console.log(`9.Senaryo Başarili`)
    }

    //10.Senaryo  
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div/label')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div/input')).sendKeys('a', Key.ENTER)
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div/input')).sendKeys(Key.RETURN)
    let name = await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div/input')).getAttribute("value")
    if (!/[^a-zA-Z]/.test(name)) {
        console.log(`10.Senaryo Başarili`)
    } else {
        console.log(`10.Senaryo Başarsiz`)
    }
    //11.Senaryo
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[1]/div/div/div/div/div')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[3]/div/div/div/div/div')).click()
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[3]/div/div/div/div/div/input')).sendKeys('a', Key.ENTER)
    await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[3]/div/div/div/div/div/input')).sendKeys(Key.RETURN)
    let fiyat = await driver.findElement(By.xpath('/html/body/div/div/div/div/main/div/div/div/div[1]/div[1]/div/div[2]/div[3]/div/div/div/div/div/input')).getAttribute("value")
    if (!/[^a-zA-Z]/.test(fiyat)) {
        console.log(`11.Senaryo Başarsiz`)
    } else {
        console.log(`11.Senaryo Başarili`)
    }








})()